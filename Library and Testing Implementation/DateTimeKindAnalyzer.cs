
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CodeAnalyzer.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DateTimeKindAnalyzer : BaseDiagnosticAnalyzer
    {
        public const string DiagnosticId = "AN0002";
        private const string Title = "DateTime should be UTC";
        private const string MessageFormat = "DateTime kind should be UTC";
        private const string Description = "DateTime kind should be UTC";
        private const string Category = "Usage";

        private const string SYSTEM_DATETIME = "System.DateTime";
        private const string DATETIME = "DateTime";
        private const string NOW = "Now";
        private const string DATETIMEKIND = "DateTimeKind";
        private const string UTC = "Utc";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            base.Initialize(context);

            context.RegisterSyntaxNodeAction(AnalyzeLocalDeclarationStatement, SyntaxKind.LocalDeclarationStatement);
            context.RegisterSyntaxNodeAction(AnalyzeArgument, SyntaxKind.Argument);

            context.RegisterCompilationStartAction(startContext =>
            {
                INamedTypeSymbol dateTimeSymbol = startContext.Compilation.GetTypeByMetadataName(SYSTEM_DATETIME);

                if (dateTimeSymbol is null)
                {
                    return;
                }

                startContext.RegisterSyntaxNodeAction(
                    nodeContext => AnalyzeObjectCreationExpression(nodeContext, dateTimeSymbol),
                    SyntaxKind.ObjectCreationExpression);
            });
        }

        private static void AnalyzeLocalDeclarationStatement(SyntaxNodeAnalysisContext context)
        {
            var localDeclaration = (LocalDeclarationStatementSyntax)context.Node;

            foreach (var variable in localDeclaration.Declaration.Variables)
            {
                var initializer = variable.Initializer;
                if (initializer == null)
                {
                    return;
                }

                AnalyzeExpressionSyntax(context, initializer.Value);
            }
        }

        private static void AnalyzeArgument(SyntaxNodeAnalysisContext context)
        {
            var argumentSyntax = (ArgumentSyntax)context.Node;
            AnalyzeExpressionSyntax(context, argumentSyntax.Expression);
        }

        private static void AnalyzeObjectCreationExpression(SyntaxNodeAnalysisContext context, INamedTypeSymbol dateTimeSymbol)
        {
            var objectCreationSyntax = (ObjectCreationExpressionSyntax)context.Node;

            ITypeSymbol typeSymbol = context.SemanticModel.GetTypeSymbol(objectCreationSyntax, context.CancellationToken);
            if (typeSymbol?.Equals(dateTimeSymbol) != true)
            {
                return;
            }

            var dateTimeKindArgument = objectCreationSyntax.ArgumentList.Arguments.FirstOrDefault(e =>
                                        (e is ArgumentSyntax argumentSyntax)
                                        && (argumentSyntax.Expression is MemberAccessExpressionSyntax memberSyntax)
                                        && (memberSyntax.Expression is IdentifierNameSyntax idSyntax)
                                        && idSyntax.Identifier.ValueText == DATETIMEKIND);

            if (dateTimeKindArgument is null)
            {
                context.ReportDiagnostic(Diagnostic.Create(Rule, context.Node.GetLocation()));
            }
            else if (dateTimeKindArgument.Expression.TryGetInferredMemberName() != UTC)
            {
                context.ReportDiagnostic(Diagnostic.Create(Rule, context.Node.GetLocation()));
            }
        }

        private static void AnalyzeExpressionSyntax(SyntaxNodeAnalysisContext context, ExpressionSyntax expressionSyntax)
        {
            if (!(expressionSyntax is MemberAccessExpressionSyntax memberAccessExpressionSyntax))
            {
                return;
            }

            if (!(memberAccessExpressionSyntax.Expression is IdentifierNameSyntax identifierNameSyntax))
            {
                return;
            }

            if (identifierNameSyntax.Identifier.ValueText != DATETIME)
            {
                return;
            }

            var memberName = memberAccessExpressionSyntax.TryGetInferredMemberName();
            if (memberName != NOW)
            {
                return;
            }

            context.ReportDiagnostic(Diagnostic.Create(Rule, context.Node.GetLocation()));
        }
    }
}
