//using CodeAnalyzer.Analyzers;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CodeFixes;
//using Microsoft.CodeAnalysis.Diagnostics;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using TestHelper;

//namespace CodeAnalyzer.Test
//{
//	[TestClass]
//	public class ConstantAnalyzerUnitTest : CodeFixVerifier
//	{
//		[TestMethod]
//		public void ConstantAnalyzer_CouldMakeConstant_ProposeFix()
//		{
//			var test = @"
//namespace ConsoleApplication1
//{
//	class TypeName
//	{   
//		static void Main(string[] args)
//		{
//			int i = 1;
//			int j = 2;
//			int k = i + j;
//		}
//	}
//}";

//			var expected1 = new DiagnosticResult
//			{
//				Id = "MakeConstCS",
//				Message = String.Format("Can be made constant"),
//				Severity = DiagnosticSeverity.Warning,
//				Locations =
//					new[] {
//							new DiagnosticResultLocation("Test0.cs", 8,4)
//						}
//			};

//			var expected2 = new DiagnosticResult
//			{
//				Id = "MakeConstCS",
//				Message = String.Format("Can be made constant"),
//				Severity = DiagnosticSeverity.Warning,
//				Locations =
//				new[] {
//							new DiagnosticResultLocation("Test0.cs", 9,4)
//						}
//			};

//			VerifyCSharpDiagnostic(test, expected1, expected2);

//			var fixtest = @"
//namespace ConsoleApplication1
//{
//	class TypeName
//	{   
//		static void Main(string[] args)
//		{
//            const int i = 1;
//            const int j = 2;
//            int k = i + j;
//		}
//	}
//}";

//			VerifyCSharpFix(test, fixtest, null, true);
//		}

//		protected override CodeFixProvider GetCSharpCodeFixProvider()
//		{
//			return new ConstantFixProvider();
//		}

//		protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
//		{
//			return new ConstantAnalyzer();
//		}
//	}
//}
