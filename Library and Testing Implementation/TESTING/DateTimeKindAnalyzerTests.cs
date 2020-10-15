
using CodeAnalyzer.Analyzers;
using CodeAnalyzer.Test.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestHelper;

namespace CodeAnalyzer.Test
{
	[TestClass]
	public class DateTimeKindAnalyzerTests : CodeFixVerifier
	{
		[TestMethod]
		public void DateTimeAnalyzer_InitializeDateTimeNow_ProposeFix()
		{
			var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			DateTime date = DateTime.Now;
		}
	}
}";

			var expected = new DiagnosticResult
			{
				Id = "AN0002",
				Message = String.Format("DateTime kind should be UTC"),
				Severity = DiagnosticSeverity.Warning,
				Locations =
					new[] {
							new DiagnosticResultLocation("Test0.cs", 8,4)
						}
			};

			VerifyCSharpDiagnostic(test, expected);
		}

		[TestMethod]
		public void DateTimeAnalyzer_InitializeDateTimeLocal_ProposeFix()
		{
			var test = @"
using System;
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			DateTime dateTime = new DateTime(0, 0, 0, 0, 0, 0, DateTimeKind.Local);
		}
	}
}";

			var expected = new DiagnosticResult
			{
				Id = "AN0002",
				Message = String.Format("DateTime kind should be UTC"),
				Severity = DiagnosticSeverity.Warning,
				Locations =
					new[] {
							new DiagnosticResultLocation("Test0.cs", 9,24)
						}
			};

			VerifyCSharpDiagnostic(test, expected);
		}

		[TestMethod]
		public void DateTimeAnalyzer_InitializeDateTimeTicks_ProposeFix()
		{
			var nameSpace = @"using System;";
			var method = @"DateTime dateTime = new DateTime(0);";

			var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

			var expected = CodeTestHelper.CreateDiagnosticResult("AN0002", "DateTime kind should be UTC", 9, 24);

			VerifyCSharpDiagnostic(test, expected);
		}

		[TestMethod]
		public void DateTimeAnalyzer_DateTimeNowMethodParameter_ProposeFix()
		{
			var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			MyMethod(DateTime.Now);
		}

		private static MyMethod(DateTime dateTime)
		{
		}
	}
}";

			var expected = new DiagnosticResult
			{
				Id = "AN0002",
				Message = String.Format("DateTime kind should be UTC"),
				Severity = DiagnosticSeverity.Warning,
				Locations =
					new[] {
							new DiagnosticResultLocation("Test0.cs", 8,13)
						}
			};

			VerifyCSharpDiagnostic(test, expected);
		}

		protected override CodeFixProvider GetCSharpCodeFixProvider()
		{
			return new ConstantFixProvider();
		}

		protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
		{
			return new DateTimeKindAnalyzer();
		}


	}
}
