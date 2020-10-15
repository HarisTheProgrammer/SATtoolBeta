using CodeAnalyzer.Analyzers;
using CodeAnalyzer.Test.Helpers;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace CodeAnalyzer.Test
{
    [TestClass]
    public class CollectionContainsAnalyzerTests : CodeFixVerifier
    {
        [TestMethod]
        public void CollectionContainsAnalyzer_HashSetAnyCouldBeContainsLeft_ProposeFix()
        {
            var namespaces = @"
using System.Collections.Generic;
using System.Linq;
    ";

            var methodBody = @"
            var collection = new HashSet<string>();
            var result = collection.Any(e => e == ""test"");
            ";

            var code = CodeTestHelper.GetCodeInMainMethod(namespaces, methodBody);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0010", 14, 41);

            VerifyCSharpDiagnostic(code, expected);
        }

        [TestMethod]
        public void CollectionContainsAnalyzer_HashSetAnyCouldBeContainsRight_ProposeFix()
        {
            var namespaces = @"
using System.Collections.Generic;
using System.Linq;
    ";

            var methodBody = @"
            var collection = new HashSet<string>();
            var result = collection.Any(e => ""test"" == e);
            ";

            var code = CodeTestHelper.GetCodeInMainMethod(namespaces, methodBody);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0010", 14, 41);

            VerifyCSharpDiagnostic(code, expected);
        }

        [TestMethod]
        public void CollectionContainsAnalyzer_HashSetAnyIntCouldBeContainsLeft_ProposeFix()
        {
            var namespaces = @"
using System.Collections.Generic;
using System.Linq;
    ";

            var methodBody = @"
            var collection = new HashSet<int>();
            var result = collection.Any(e => e == 5);
            ";

            var code = CodeTestHelper.GetCodeInMainMethod(namespaces, methodBody);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0010", 14, 41);

            VerifyCSharpDiagnostic(code, expected);
        }

        [TestMethod]
        public void CollectionContainsAnalyzer_HashSetAnyIntCouldBeContainsRight_ProposeFix()
        {
            var namespaces = @"
using System.Collections.Generic;
using System.Linq;
    ";

            var methodBody = @"
            var collection = new HashSet<int>();
            var result = collection.Any(e => 5 == e);
            ";

            var code = CodeTestHelper.GetCodeInMainMethod(namespaces, methodBody);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0010", 14, 41);

            VerifyCSharpDiagnostic(code, expected);
        }

        [TestMethod]
        public void CollectionContainsAnalyzer_ListAnyCouldBeContainsLeft_ProposeFix()
        {
            var namespaces = @"
using System.Collections.Generic;
using System.Linq;
    ";

            var methodBody = @"
            var collection = new List<string>();
            var result = collection.Any(e => e == ""test"");
            ";

            var code = CodeTestHelper.GetCodeInMainMethod(namespaces, methodBody);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0010", 14, 41);

            VerifyCSharpDiagnostic(code, expected);
        }

        [TestMethod]
        public void CollectionContainsAnalyzer_ListAnyCouldBeContainsRight_ProposeFix()
        {
            var namespaces = @"
using System.Collections.Generic;
using System.Linq;
    ";

            var methodBody = @"
            var collection = new List<string>();
            var result = collection.Any(e => ""test"" == e);
            ";

            var code = CodeTestHelper.GetCodeInMainMethod(namespaces, methodBody);

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0010", 14, 41);

            VerifyCSharpDiagnostic(code, expected);
        }

        [TestMethod]
        public void CollectionContainsAnalyzer_HashSetAnyLessThan_Ignore()
        {
            var namespaces = @"
using System.Collections.Generic;
using System.Linq;
    ";

            var methodBody = @"
            var collection = new HashSet<int>();
            var result = collection.Any(e => e < 2);
            ";

            var code = CodeTestHelper.GetCodeInMainMethod(namespaces, methodBody);

            VerifyCSharpDiagnostic(code);
        }

        [TestMethod]
        public void CollectionContainsAnalyzer_HashSetAnyGreaterThan_Ignore()
        {
            var namespaces = @"
using System.Collections.Generic;
using System.Linq;
    ";

            var methodBody = @"
            var collection = new HashSet<int>();
            var result = collection.Any(e => e > 2);
            ";

            var code = CodeTestHelper.GetCodeInMainMethod(namespaces, methodBody);

            VerifyCSharpDiagnostic(code);
        }

        [TestMethod]
        public void CollectionContainsAnalyzer_HashSetAnyEmpty_Ignore()
        {
            var namespaces = @"
using System.Collections.Generic;
using System.Linq;
    ";

            var methodBody = @"
            var collection = new HashSet<int>();
            var result = collection.Any();
            ";

            var code = CodeTestHelper.GetCodeInMainMethod(namespaces, methodBody);

            VerifyCSharpDiagnostic(code);
        }

        [TestMethod]
        public void CollectionContainsAnalyzer_HashSetAnyAndExpression_Ignore()
        {
            var namespaces = @"
using System.Collections.Generic;
using System.Linq;
    ";

            var methodBody = @"
            var collection = new HashSet<string>();
            var result = collection.Any(e => e == ""test"" && e == ""othertest"");
            ";

            var code = CodeTestHelper.GetCodeInMainMethod(namespaces, methodBody);

            VerifyCSharpDiagnostic(code);
        }

        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return new ConstantFixProvider();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new CollectionContainsAnalyzer();
        }
    }
}
