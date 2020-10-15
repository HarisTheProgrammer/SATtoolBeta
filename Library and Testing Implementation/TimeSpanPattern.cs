using System.Text.RegularExpressions;
using CodeAnalyzer.Analyzers;
using Microsoft.CodeAnalysis;

namespace CodeAnalyzer.Entities
{
    public class TimeSpanPattern
    {
        public TimeSpanPattern(Regex pattern, DiagnosticDescriptor rule)
        {
            Pattern = pattern;
            Rule = rule;
        }

        public TimeSpanPattern(Regex pattern, string message)
        {
            Pattern = pattern;
            Rule = new DiagnosticDescriptor(TimeSpanFormatAnalyzer.DiagnosticId, TimeSpanFormatAnalyzer.Title, message, TimeSpanFormatAnalyzer.Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: TimeSpanFormatAnalyzer.Description);
        }

        public Regex Pattern { get; private set; }

        public DiagnosticDescriptor Rule { get; private set; }

    }
}
