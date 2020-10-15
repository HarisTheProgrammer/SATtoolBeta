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
	public class UnitTestAssertionTests : CodeFixVerifier
	{
		[TestMethod]
		public void UnitTestAssertionAnalyzer_NoAssert_ProposeFix()
		{
			var test = @"
namespace ConsoleApplication1
{
	[TestClass]
	public class TestClass
	{
		[TestMethod]
		public void TestMethodName()
		{
			int i = 1;
			int j = 2;
			int k = i + j;
		}
	}
}";

			var expected = new DiagnosticResult
			{
				Id = "AN0005",
				Message = String.Format("Add assertion in test"),
				Severity = DiagnosticSeverity.Info,
				Locations =
					new[] {
							new DiagnosticResultLocation("Test0.cs", 7,3)
						}
			};

			VerifyCSharpDiagnostic(test, expected);
		}

		[TestMethod]
		public void UnitTestAssertionAnalyzer_ShouldAssert_Ignore()
		{
			var test = @"
namespace ConsoleApplication1
{
	[TestClass]
	public class TestClass
	{
		[TestMethod]
		public void TestMethodName()
		{
			int k = 1 + 2;
			j.Should().Be(3);
		}
	}
}";

			VerifyCSharpDiagnostic(test);
		}

		[TestMethod]
		public void UnitTestAssertionAnalyzer_AssertMethodInvoked_Ignore()
		{
			var test = @"
namespace ConsoleApplication1
{
	[TestClass]
	public class TestClass
	{
		[TestMethod]
		public void TestMethodName()
		{
			int k = 1 + 2;
			TestResult(k);
		}
		
		private void TestResult(int k)
		{
			k.Should().Be(1)
		}
	}
}";

			VerifyCSharpDiagnostic(test);
		}

		[TestMethod]
		public void UnitTestAssertionAnalyzer_ResursiveMethod_Ignore()
		{
			var test = @"
namespace ConsoleApplication1
{
	[TestClass]
	public class TestClass
	{
		[TestMethod]
		public void TestMethodName()
		{
			TestResult(1);
		}
		
		private void TestResult(int k)
		{
			TestResult(k);
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
			return new UnitTestAssertionAnalyzer();
		}

	}
}
