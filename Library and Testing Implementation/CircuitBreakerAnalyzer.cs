using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
//Circuit Breaker Function
namespace CodeAnalyzer.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class CircuitBreakerAnalyzer : BaseDiagnosticAnalyzer
    {
        public const string DiagnosticId = "AN0001";
        private const string Title = "Circuit breaker in loop";
        private const string MessageFormat = "Add circuit breaker to loop";
        private const string Description = "Add circuit breaker to loop";
        private const string Category = "Usage";
        //The Goal of this library function is to detect a circuit breaker inside a porgram and inform the user if the code contains such an error through static analysis.
        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }
        //initialize the context of a circuit breaker, create an instance 
        public override void Initialize(AnalysisContext context)
        {
            base.Initialize(context);
            context.EnableConcurrentExecution();

            context.RegisterSyntaxNodeAction(AnalyzeWhileStatement, SyntaxKind.WhileStatement);
            context.RegisterSyntaxNodeAction(AnalyzeForStatement, SyntaxKind.ForStatement);
        }
        //Analyse a while statement
        private static void AnalyzeWhileStatement(SyntaxNodeAnalysisContext context)
        {
            var whileStatement = (WhileStatementSyntax)context.Node;

            if (!(whileStatement.Statement is BlockSyntax))
            {
                return;
            }
            if (HasConditionCircuitBreaker(whileStatement.Condition, whileStatement.Statement))
            {
                return;
            }
            if (HasStatementCircuitBreaker(whileStatement.Statement))
            {
                return;
            }

            context.ReportDiagnostic(Diagnostic.Create(Rule, whileStatement.WhileKeyword.GetLocation()));
        }
        //Method for a positive test of a circuit breaker 
        private static bool HasConditionCircuitBreaker(ExpressionSyntax condition, StatementSyntax statement)
        {
            if (condition is BinaryExpressionSyntax binaryExpression)
            {
                if (binaryExpression.Kind() == SyntaxKind.LessThanExpression
                    || binaryExpression.Kind() == SyntaxKind.LessThanOrEqualExpression)
                {
                    if (binaryExpression.Left is IdentifierNameSyntax leftIdenfitierSyntax
                        && HasIncrementingStamentIdentifier(statement, leftIdenfitierSyntax))
                    {
                        return true;
                    }
                    else if (binaryExpression.Right is IdentifierNameSyntax rightIdentifierSyntax
                        && HasDecrementingStamentIdentifier(statement, rightIdentifierSyntax))
                    {
                        return true;
                    }
                }
                if (binaryExpression.Kind() == SyntaxKind.GreaterThanExpression
                    || binaryExpression.Kind() == SyntaxKind.GreaterThanOrEqualExpression)
                {
                    if (binaryExpression.Left is IdentifierNameSyntax leftIdenfitierSyntax
                        && HasDecrementingStamentIdentifier(statement, leftIdenfitierSyntax))
                    {
                        return true;
                    }
                    else if (binaryExpression.Right is IdentifierNameSyntax rightIdentifierSyntax
                        && HasIncrementingStamentIdentifier(statement, rightIdentifierSyntax))
                    {
                        return true;
                    }
                }

                if (HasConditionCircuitBreaker(binaryExpression.Left, statement))
                {
                    return true;
                }
                if (HasConditionCircuitBreaker(binaryExpression.Right, statement))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasIncrementingStamentIdentifier(StatementSyntax statement, IdentifierNameSyntax identifierNameSyntax)
        {
            IncrementDecrementType requiredChange = IncrementDecrementType.Increment;
            if (HasChangingIdentifier(statement, identifierNameSyntax, requiredChange))
            {
                return true;
            }

            return false;
        }

        private static bool HasDecrementingStamentIdentifier(StatementSyntax statement, IdentifierNameSyntax identifierNameSyntax)
        {
            IncrementDecrementType requiredChange = IncrementDecrementType.Decrement;
            if (HasChangingIdentifier(statement, identifierNameSyntax, requiredChange))
            {
                return true;
            }

            return false;
        }

        private static void AnalyzeForStatement(SyntaxNodeAnalysisContext context)
        {
            var forStatement = (ForStatementSyntax)context.Node;

            if (forStatement.Incrementors.Count == 0
                && forStatement.Initializers.Count == 0
                && !forStatement.OpenParenToken.ContainsDirectives
                && !forStatement.FirstSemicolonToken.ContainsDirectives
                && !forStatement.SecondSemicolonToken.ContainsDirectives
                && !forStatement.CloseParenToken.ContainsDirectives)
            {
                if (!(forStatement.Statement is BlockSyntax))
                {
                    return;
                }

                if (!HasStatementCircuitBreaker(forStatement.Statement))
                {
                    context.ReportDiagnostic(Diagnostic.Create(Rule, forStatement.ForKeyword.GetLocation()));
                }
            }
        }

        private static bool HasStatementCircuitBreaker(StatementSyntax statementSyntax)
        {
            if (statementSyntax is BreakStatementSyntax
                    || statementSyntax is ReturnStatementSyntax)
            {
                return true; 
            }

            if (!(statementSyntax is BlockSyntax blockSyntax))
            {
                return false;
            }

            foreach (var statement in blockSyntax.Statements)
            {
                if (statement is BreakStatementSyntax
                    || statement is ReturnStatementSyntax)
                {
                    return true;
                }
                else if (statement is IfStatementSyntax ifStatementSyntax)
                {
                    if (HasStatementCircuitBreaker(ifStatementSyntax.Statement)
                        || HasStatementCircuitBreaker(ifStatementSyntax?.Else?.Statement))
                    {
                        return true;
                    }
                }
                else if (HasStatementCircuitBreaker(statement))
                {
                    return true;
                }
            }

            return false;
        }

        private enum IncrementDecrementType
        {
            Increment,
            Decrement
        }

        private static bool HasChangingIdentifier(StatementSyntax statementSyntax, IdentifierNameSyntax identifierNameSyntax, IncrementDecrementType requiredChange)
        {
            if (!(statementSyntax is BlockSyntax blockSyntax))
            {
                return false;
            }

            foreach (var statement in blockSyntax.Statements)
            {
                if (statement is IfStatementSyntax ifStatementSyntax)
                {
                    if (HasChangingIdentifier(ifStatementSyntax.Statement, identifierNameSyntax, requiredChange))
                    {
                        return true;
                    }
                    if (HasChangingIdentifier(ifStatementSyntax?.Else?.Statement, identifierNameSyntax, requiredChange))
                    {
                        return true;
                    }
                }
                else if (statement is ExpressionStatementSyntax expressionStatementSyntax)
                {
                    if (expressionStatementSyntax.Expression is PostfixUnaryExpressionSyntax postExpressionSyntax)
                    {
                        if (postExpressionSyntax.Operand is IdentifierNameSyntax statementIdentifierNameSyntax
                            && statementIdentifierNameSyntax.Identifier.Text == identifierNameSyntax.Identifier.Text
                            && MatchesIntegerChange(requiredChange, postExpressionSyntax.OperatorToken.Kind()))
                        {
                            return true;
                        }
                    }
                    if (expressionStatementSyntax.Expression is PrefixUnaryExpressionSyntax prefixExpressionSyntax)
                    {
                        if (prefixExpressionSyntax.Operand is IdentifierNameSyntax statementIdentifierNameSyntax
                            && statementIdentifierNameSyntax.Identifier.Text == identifierNameSyntax.Identifier.Text
                            && MatchesIntegerChange(requiredChange, prefixExpressionSyntax.OperatorToken.Kind()))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static bool MatchesIntegerChange(IncrementDecrementType requiredChange, SyntaxKind stamentSyntaxKind)
        {
            if (requiredChange == IncrementDecrementType.Decrement)
            {
                return stamentSyntaxKind == SyntaxKind.MinusMinusToken;
            }

            return stamentSyntaxKind == SyntaxKind.PlusPlusToken;
        }
    }
}
