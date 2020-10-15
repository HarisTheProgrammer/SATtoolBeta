using System.Collections.Immutable;
using CodeAnalyzer.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CodeAnalyzer.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class CollectionContainsAnalyzer : BaseDiagnosticAnalyzer
    {
        public const string DiagnosticId = "AN0010";
        private const string Title = "Use Contains instead of Any";
        private const string MessageFormat = "Use Contains instead of Any";
        private const string Description = "Use Contains instead of Any";
        private const string Category = "Usage";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            base.Initialize(context);

            context.RegisterSyntaxNodeAction(AnalyzePossibleContains, SyntaxKind.InvocationExpression);
        }

        private static void AnalyzePossibleContains(SyntaxNodeAnalysisContext context)
        {
            var invocationExpression = (InvocationExpressionSyntax)context.Node;

            if (invocationExpression is null)
                return;

            IMethodSymbol methodSymbol = context.SemanticModel.GetExtensionMethodSymbol(invocationExpression);

            if (methodSymbol is null)
                return;

            if (!SymbolUtility.IsLinqIEnumerableWithPredicate(methodSymbol, "Any"))
                return;

            if (invocationExpression.ArgumentList != null)
            {
                foreach (var argument in invocationExpression.ArgumentList.Arguments)
                {
                    if (argument.Expression is SimpleLambdaExpressionSyntax simpleLambdaExpression
                        && simpleLambdaExpression.Body is BinaryExpressionSyntax binaryExpression)
                    {
                        if (binaryExpression.OperatorToken.Kind() == SyntaxKind.EqualsEqualsToken)
                        {
                            var parameter = simpleLambdaExpression.Parameter.Identifier;

                            if (binaryExpression.Left is IdentifierNameSyntax leftIdentifier
                                && leftIdentifier.Identifier.ValueText == parameter.ValueText)
                            {
                                context.ReportDiagnostic(Diagnostic.Create(Rule, argument.GetLocation()));
                            }
                            else if (binaryExpression.Right is IdentifierNameSyntax rightIdentifier
                                && rightIdentifier.Identifier.ValueText == parameter.ValueText)
                            {
                                context.ReportDiagnostic(Diagnostic.Create(Rule, argument.GetLocation()));
                            }
                        }
                    }
                }
            }
        }
    }
}
