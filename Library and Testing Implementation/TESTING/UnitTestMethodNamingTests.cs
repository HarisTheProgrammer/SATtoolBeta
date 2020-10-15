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
	public class UnitTestMethodNamingTests : CodeFixVerifier
	{
		[TestMethod]
		public void UnitTestMethodNamingAnalyzer_IncorrectConvention_ProposeFix()
		{
			var test = @"
namespace ConsoleApplication1
{
	[TestClass]
	public class TestClass
	{
		[TestMethod]
		public void BadTestMethodName()
		{
		}
	}
}";

			var expected = new DiagnosticResult
			{
				Id = "AN0006",
				Message = String.Format("Use unit test method naming convention: [UnitToTest]_[Scenario]_[ExpectedOutcome]"),
				Severity = DiagnosticSeverity.Info,
				Locations =
					new[] {
							new DiagnosticResultLocation("Test0.cs", 7,3)
						}
			};

			VerifyCSharpDiagnostic(test, expected);
		}

		[TestMethod]
		public void UnitTestMethodNamingAnalyzer_CorrectConvention_Ignore()
		{
			var test = @"
namespace ConsoleApplication1
{
	[TestClass]
	public class TestClass
	{
		[TestMethod]
		public void Good_Test_Name()
		{
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
			return new UnitTestMethodNamingAnalyzer();
		}

	}
}
