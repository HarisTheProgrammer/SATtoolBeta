using CodeAnalyzer.Analyzers;
using CodeAnalyzer.Test.Helpers;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace CodeAnalyzer.Test
{
    [TestClass]
    public class DateFormatAnalyzerTests : CodeFixVerifier
    {
        [TestMethod]
        public void DateFormatAnalyzer_DateTimeyyyymmdd_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""yyyy/mm/dd"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeyyyyMMdd_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""yyyy/MM/dd"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DateFormatAnalyzer_DateTimemmddyyyy_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""mm/dd/yyyy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeMMddyyyy_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""MM/dd/yyyy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DateFormatAnalyzer_DateTimeddmmyyyy_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""dd/mm/yyyy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeddMMyyyy_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""dd/MM/yyyy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DateFormatAnalyzer_DateTimeyymmdd_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""yy/mm/dd"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeyyMMdd_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""yy/MM/dd"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DateFormatAnalyzer_DateTimemmddyy_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""mm/dd/yy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeMMddyy_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""MM/dd/yy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DateFormatAnalyzer_DateTimeddmmyy_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""dd/mm/yy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeddMMyy_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTime.UtcNow.ToString(""dd/MM/yy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetyyyymmdd_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""yyyy/mm/dd"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetyyyyMMdd_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""yyyy/MM/dd"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetmmddyyyy_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""mm/dd/yyyy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetMMddyyyy_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""MM/dd/yyyy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetddmmyyyy_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""dd/mm/yyyy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetddMMyyyy_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""dd/MM/yyyy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetyymmdd_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""yy/mm/dd"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetyyMMdd_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""yy/MM/dd"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetmmddyy_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""mm/dd/yy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetMMddyy_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""MM/dd/yy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetddmmyy_ProposeFix()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""dd/mm/yy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0008", 9, 15);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void DateFormatAnalyzer_DateTimeOffsetddMMyy_Ignore()
        {
            var nameSpace = @"using System;";
            var method = @"var date = DateTimeOffset.UtcNow.ToString(""dd/MM/yy"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);


            VerifyCSharpDiagnostic(test);
        }

        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return new ConstantFixProvider();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new DateFormatAnalyzer();
        }

    }
}
