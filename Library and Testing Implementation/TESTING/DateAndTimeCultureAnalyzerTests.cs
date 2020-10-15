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
	public class DateAndTimeCultureAnalyzerTests : CodeFixVerifier
	{
		[TestMethod]
		public void DateAndTimeStringAnalyzer_ToStringWitInvarientCulture_Ignore()
		{
			var test = @"
using System;
using System.Globalization;
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			var date = DateTime.UtcNow.ToString(""yyyy/MM/dd"", CultureInfo.InvariantCulture);
		}
	}
}";

			VerifyCSharpDiagnostic(test);
		}

		[TestMethod]
		public void DateAndTimeStringAnalyzer_ToStringWithoutInvarientCulture_ProposeFix()
		{
			var test = @"
using System;
using System.Globalization;
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			var date = DateTime.UtcNow.ToString(""yyyy/MM/dd"");
		}
	}
}";

			var expected = new DiagnosticResult
			{
				Id = "AN0007",
				Message = String.Format("Use InvariantCulture for printing date/time"),
				Severity = DiagnosticSeverity.Warning,
				Locations =
					new[] { new DiagnosticResultLocation("Test0.cs", 10, 15) }
			};

			VerifyCSharpDiagnostic(test, expected);
		}

		[TestMethod]
		public void DateAndTimeStringAnalyzer_DateTimeOffsetToStringWithoutInvariantCulture_ProposeFix()
		{
			var nameSpace = @"using System;";
			var method = @"string dateTimeOffset = new DateTimeOffset(0, new TimeSpan(0)).ToString(""mm/dd/yyyy hh:mm:ss"");";

			var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

			var expected = CodeTestHelper.CreateDiagnosticResult("AN0007", "Use InvariantCulture for printing date/time", 9, 28);

			VerifyCSharpDiagnostic(test, expected);
		}

		[TestMethod]
		public void DateAndTimeStringAnalyzer_TimeSpanToStringWithoutInvariantCulture_ProposeFix()
		{
			var nameSpace = @"using System;";
			var method = @"var timeSpan = new TimeSpan(0).ToString(""mm/dd/yyyy hh:mm:ss"");";

			var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

			var expected = CodeTestHelper.CreateDiagnosticResult("AN0007", "Use InvariantCulture for printing date/time", 9, 19);

			VerifyCSharpDiagnostic(test, expected);
		}



		protected override CodeFixProvider GetCSharpCodeFixProvider()
		{
			return null;
		}

		protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
		{
			return new DateAndTimeCultureAnalyzer();
		}
	}
}
