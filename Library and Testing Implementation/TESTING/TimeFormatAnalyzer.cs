using CodeAnalyzer.Analyzers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestHelper;

namespace CodeAnalyzer.Test
{
	[TestClass]
	public class TimeFormatAnalyzerTests : CodeFixVerifier
	{
		[TestMethod]
		public void TimeFormatAnalyzer_12hourFormat_ProposeFix()
		{
			var test = @"
using System;
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			var date = DateTime.Now.ToString(""mm/dd/yyyy hh:mm:ss"");
		}
	}
}";

			var expected = new DiagnosticResult
			{
				Id = "AN0004",
				Message = String.Format("Use 24 hour time format"),
				Severity = DiagnosticSeverity.Warning,
				Locations =
					new[] {
							new DiagnosticResultLocation("Test0.cs", 9,15)
						}
			};

			VerifyCSharpDiagnostic(test, expected);
		}

		[TestMethod]
		public void TimeFormatAnalyzer_24hourFormat_Ignore()
		{
			var test = @"
using System;
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			var date = DateTime.Now.ToString(""mm/dd/yyyy HH:mm:ss"");
		}
	}
}";


			VerifyCSharpDiagnostic(test);
		}

		protected override CodeFixProvider GetCSharpCodeFixProvider()
		{
			return new ConstantFixProvider();
		}

		protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
		{
			return new TimeFormatAnalyzer();
		}

	}
}
