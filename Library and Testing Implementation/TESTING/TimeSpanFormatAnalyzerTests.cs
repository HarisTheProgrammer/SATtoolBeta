using CodeAnalyzer.Analyzers;
using CodeAnalyzer.Test.Helpers;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace CodeAnalyzer.Test
{
    [TestClass]
    public class TimeSpanFormatAnalyzerTests : CodeFixVerifier
    {
        [TestMethod]
        public void TimeSpanFormatAnalyzer_y_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""y"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "Year not valid in TimeSpan formatting", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_Y_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""Yx"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "Year not valid in TimeSpan formatting", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_yy_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""yy"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "Year not valid in TimeSpan formatting", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_yyy_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""yyy"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "Year not valid in TimeSpan formatting", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_yyyy_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""yyyy"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "Year not valid in TimeSpan formatting", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_M_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""M"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "Month not valid in TimeSpan formatting. Did you mean 'm' (minutes)?", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_MM_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""MM"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "Month not valid in TimeSpan formatting. Did you mean 'm' (minutes)?", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_MMM_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""MMM"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "Month not valid in TimeSpan formatting", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_MMMM_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""MMMM"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "Month not valid in TimeSpan formatting", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_HH_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""HH"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "'HH' not valid in TimeSpan formatting. Did you mean 'hh' (hours)?", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_D_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""D"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "'D' not valid in TimeSpan formatting. Did you mean 'dd' (days)?", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_DD_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""DD"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "'DD' not valid in TimeSpan formatting. Did you mean 'dd' (days)?", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_d_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""d"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "'d' alone doesn't work in TimeSpan, use %d or in a pattern @\"d\\:h\"", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_h_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""h"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "'h' alone doesn't work in TimeSpan, use %h or in a pattern @\"h\\:m\"", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_m_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""m"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "'m' alone doesn't work in TimeSpan, use %m or in a pattern @\"m\\:s\"", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_s_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""s"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "'s' alone doesn't work in TimeSpan, use %s or in a pattern @\"s\\:f\"", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_f_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""f"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "'f' alone doesn't work in TimeSpan, use %f or in a pattern @\"f\\:ff\"", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_F_ProposeFix()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var time = new TimeSpan(20, 10, 5, 2).ToString(@""F"", CultureInfo.InvariantCulture);";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            var expected = CodeTestHelper.CreateDiagnosticResult("AN0009", "'F' alone doesn't work in TimeSpan, use %f or in a pattern @\"F\\:ff\"", 10, 15);
            VerifyCSharpDiagnostic(test, expected);
        }



        [TestMethod]
        public void TimeSpanFormatAnalyzer_percentD_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""%d"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_percentH_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""%h"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_percentM_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""%m"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_percentS_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""%s"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_percentf_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""%f"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_percentF_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""%F"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_dPattern_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""d\:h"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_hPattern_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""h\:m"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_mPattern_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""m\:s"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_sPattern_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""s\:f"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_fPattern_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""f\:ff"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void TimeSpanFormatAnalyzer_FPattern_Ignore()
        {
            var nameSpace = @"using System;
using System.Globalization;";
            var method = @"var date = new TimeSpan(20, 10, 5, 2).ToString(@""F\:ff"");";

            var test = CodeTestHelper.GetCodeInMainMethod(nameSpace, method);
            VerifyCSharpDiagnostic(test);
        }

        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return new ConstantFixProvider();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new TimeSpanFormatAnalyzer();
        }
    }
}
