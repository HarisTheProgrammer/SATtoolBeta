using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using CodeAnalyzer.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CodeAnalyzer.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class TimeSpanFormatAnalyzer : BaseDiagnosticAnalyzer
    {
        public const string DiagnosticId = "AN0009";
        public const string Title = "Invalid TimeSpan formatting";
        private const string MessageFormat = "Fix TimeSpan formatting";
        public const string Description = "Fix TimeSpan formatting";
        public const string Category = "Formatting";

        private static DiagnosticDescriptor s_DefaultRule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        private static readonly List<TimeSpanPattern> s_ForbiddenTimeSpanPatterns = new List<TimeSpanPattern>()
        {
            new TimeSpanPattern(new Regex("y"), "Year not valid in TimeSpan formatting"),
            new TimeSpanPattern(new Regex("Y"), "Year not valid in TimeSpan formatting"),
            new TimeSpanPattern(new Regex("MMMM"), "Month not valid in TimeSpan formatting"),
            new TimeSpanPattern(new Regex("MMM"), "Month not valid in TimeSpan formatting"),
            new TimeSpanPattern(new Regex("M"), "Month not valid in TimeSpan formatting. Did you mean 'm' (minutes)?"),
            new TimeSpanPattern(new Regex("HH"), "'HH' not valid in TimeSpan formatting. Did you mean 'hh' (hours)?"),
            new TimeSpanPattern(new Regex("DD"), "'DD' not valid in TimeSpan formatting. Did you mean 'dd' (days)?"),
            new TimeSpanPattern(new Regex("D"), "'D' not valid in TimeSpan formatting. Did you mean 'dd' (days)?"),
            new TimeSpanPattern(new Regex("^d$"), "'d' alone doesn't work in TimeSpan, use %d or in a pattern @\"d\\:h\""),
            new TimeSpanPattern(new Regex("^h$"), "'h' alone doesn't work in TimeSpan, use %h or in a pattern @\"h\\:m\""),
            new TimeSpanPattern(new Regex("^m$"), "'m' alone doesn't work in TimeSpan, use %m or in a pattern @\"m\\:s\""),
            new TimeSpanPattern(new Regex("^s$"), "'s' alone doesn't work in TimeSpan, use %s or in a pattern @\"s\\:f\""),
            new TimeSpanPattern(new Regex("^f$"), "'f' alone doesn't work in TimeSpan, use %f or in a pattern @\"f\\:ff\""),
            new TimeSpanPattern(new Regex("^F$"), "'F' alone doesn't work in TimeSpan, use %f or in a pattern @\"F\\:ff\"")
        };

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(s_ForbiddenTimeSpanPatterns.Select(e => e.Rule).ToArray()); } }

        public override void Initialize(AnalysisContext context)
        {
            base.Initialize(context);

            context.RegisterCompilationStartAction(startContext =>
            {
                INamedTypeSymbol timeSpanSymbol = startContext.Compilation.GetTypeByMetadataName("System.TimeSpan");

                if (timeSpanSymbol is null)
                {
                    return;
                }

                startContext.RegisterSyntaxNodeAction(
                    nodeContext => AnalyzeInvocationExpressionSyntax(nodeContext, timeSpanSymbol),
                    SyntaxKind.InvocationExpression);
            });
        }

        private static void AnalyzeInvocationExpressionSyntax(SyntaxNodeAnalysisContext context, INamedTypeSymbol timeSpanSymbol)
        {
            var invocationExpressionSyntax = (InvocationExpressionSyntax)context.Node;

            ISymbol symbol = context.SemanticModel.GetSymbol(invocationExpressionSyntax, context.CancellationToken);

            if (symbol != null)
            {
                INamedTypeSymbol containingType = symbol.ContainingType;

                if (containingType?.Equals(timeSpanSymbol) == true)
                {
                    if (symbol.Kind == SymbolKind.Method
                        && (symbol.Name == "ToString"))
                    {
                        SeparatedSyntaxList<ArgumentSyntax> arguments = invocationExpressionSyntax.ArgumentList.Arguments;

                        if (!arguments.Any())
                            return;

                        foreach (var argument in arguments)
                        {
                            if (argument.Expression is LiteralExpressionSyntax literalExpressionSyntax)
                            {
                                foreach (var pattern in s_ForbiddenTimeSpanPatterns)
                                {
                                    if (pattern.Pattern.IsMatch(literalExpressionSyntax.Token.ValueText))
                                    {
                                        context.ReportDiagnostic(Diagnostic.Create(pattern.Rule, context.Node.GetLocation()));
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
