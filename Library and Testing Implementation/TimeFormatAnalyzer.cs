using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
//A Time format analyser, converting times to 24 hour instead of 12 will help to ensure that incompatible time formats are used, therefore reducing the amount of exceptions when calling times which do not support a 24 hr format
namespace CodeAnalyzer.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class TimeFormatAnalyzer : BaseDiagnosticAnalyzer
    {
        public const string DiagnosticId = "AN0004";
        private const string Title = "24 hour format for times";
        private const string MessageFormat = "Use 24 hour time format";
        private const string Description = "Use 24 hour format instead of 12 hour format";
        private const string Category = "Formatting";
        //set the constraint variables that would be pushed to a pane if the vulnerability was detected
        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);
        //create array as part of diagnostics package
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            base.Initialize(context);
            //Identify named type, using system.DateTime format
            context.RegisterCompilationStartAction(startContext =>
            {
                INamedTypeSymbol dateTimeSymbol = startContext.Compilation.GetTypeByMetadataName("System.DateTime");

                if (dateTimeSymbol is null)
                {
                    return;
                }

                startContext.RegisterSyntaxNodeAction(
                    nodeContext => AnalyzeInvocationExpressionSyntax(nodeContext, dateTimeSymbol),
                    SyntaxKind.InvocationExpression);
            });
        }
        //Analyse symbol type compatability 
        private static void AnalyzeInvocationExpressionSyntax(SyntaxNodeAnalysisContext context, INamedTypeSymbol dateTimeSymbol)
        {
            var invocationExpressionSyntax = (InvocationExpressionSyntax)context.Node;

            ISymbol symbol = context.SemanticModel.GetSymbol(invocationExpressionSyntax, context.CancellationToken);

            if (symbol is null)
            {
                return;
            }

            INamedTypeSymbol containingType = symbol.ContainingType;

            if (containingType?.Equals(dateTimeSymbol) != true)
            {
                return;
            }

            if (symbol.Kind != SymbolKind.Method
                || (symbol.Name != "ToString"))
            {
                return;
            }

            SeparatedSyntaxList<ArgumentSyntax> arguments = invocationExpressionSyntax.ArgumentList.Arguments;

            if (!arguments.Any())
                return;
            //Report diagnostic, iterate through each argument
            foreach (var argument in arguments)
            {
                if (argument.Expression is LiteralExpressionSyntax literalExpressionSyntax)
                {
                    if (literalExpressionSyntax.Token.ValueText.Contains("hh"))
                    {
                        context.ReportDiagnostic(Diagnostic.Create(Rule, context.Node.GetLocation()));
                    }
                }
            }
        }
    }
}
