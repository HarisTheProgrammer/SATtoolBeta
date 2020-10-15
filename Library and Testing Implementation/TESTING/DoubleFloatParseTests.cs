using System;
using CodeAnalyzer.Analyzers;
using CodeAnalyzer.Test.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace CodeAnalyzer.Test
{
    [TestClass]
    public class DoubleFloatParseTests : CodeFixVerifier
    {
        [TestMethod]
        public void DoubleParseAnalyzer_ParseWithInvarientCulture_Ignore()
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
			double parsedDouble = double.Parse(""1.1"", NumberStyles.Any, CultureInfo.InvariantCulture);
		}
	}
}";


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DoubleParseAnalyzer_ParseWithoutInvarientCulture_ProposeFix()
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
			double parsedDouble = double.Parse(""1.1"");
		}
	}
}";

            var expected = new DiagnosticResult
            {
                Id = "AN0003",
                Message = String.Format("Use InvariantCulture for double/float parsing"),
                Severity = DiagnosticSeverity.Warning,
                Locations =
                    new[] { new DiagnosticResultLocation("Test0.cs", 10, 26) }
            };

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void DoubleParseAnalyzer_TryParseWithInvarientCulture_Ignore()
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
			bool didParse = double.TryParse(""1.1"", NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedDouble);
		}
	}
}";


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DoubleParseAnalyzer_TryParseWithoutInvarientCulture_ProposeFix()
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
			bool didParse = double.TryParse(""1.1"", out double parsedDouble);
		}
	}
}";

            var expected = new DiagnosticResult
            {
                Id = "AN0003",
                Message = String.Format("Use InvariantCulture for double/float parsing"),
                Severity = DiagnosticSeverity.Warning,
                Locations =
                    new[] { new DiagnosticResultLocation("Test0.cs", 10, 20) }
            };

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DoubleFloatParseAnalyzer_ParseWithInvarientCulture_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"float parsed = float.Parse(""1.1"", NumberStyles.Any, CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DoubleFloatParseAnalyzer_ParseFloatWithoutInvarientCulture_ProposeFix()
        {

            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"float parsed = float.Parse(""1.1"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0003", "Use InvariantCulture for double/float parsing", 10, 19);

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void DoubleFloatParseAnalyzer_TryParseFloatWithInvarientCulture_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"bool didParse = float.TryParse(""1.1"", NumberStyles.Any, CultureInfo.InvariantCulture, out float parsedDouble);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DoubleFloatParseAnalyzer_TryParseFloatWithoutInvarientCulture_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"bool didParse = float.TryParse(""1.1"", out float parsedFloat);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0003", "Use InvariantCulture for double/float parsing", 10, 20);

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void DoubleFloatParseAnalyzer_TryParseDoubleInvariantCultureNumberInfo_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"double.TryParse(""1.1"", NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture.NumberFormat, out double longitude);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            VerifyCSharpDiagnostic(test);
        }



        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return null;
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new DoubleFloatParseAnalyzer();
        }
    }
}
