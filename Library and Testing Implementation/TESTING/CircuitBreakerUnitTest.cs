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
    public class CircuitBreakerUnitTest : CodeFixVerifier
    {
        [TestMethod]
        public void CircuitBreakerAnalyzer_WhileNoBreak_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(i < 10)
			{
				i--;
				i++;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_WhileWithBreak_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(i < 10)
			{
				i--;
				i++;
				break;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }


        [TestMethod]
        public void CircuitBreakerAnalyzer_WhileWithReturn_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(i < 10)
			{
				i--;
				i++;
				return;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }


        [TestMethod]
        public void CircuitBreakerAnalyzer_ForWithoutIncrementerNoBreak_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			for(int i = i; i < 10;)
			{
				int o = 1;
			}
		}
	}
}";

            var expected = new DiagnosticResult
            {
                Id = "AN0001",
                Message = String.Format("Add circuit breaker to loop"),
                Severity = DiagnosticSeverity.Warning,
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test0.cs", 8,4)
                        }
            };

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ForWithIncrementerNoBreak_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			for(int i = i; i < 10; i++)
			{
				int o = 1;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ForWithBreak_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			for(int i = i; i < 10;)
			{
				int o = 1;
				break;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ForWithoutConditionNoBreak_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			for(;;)
			{
				int o = 1;
			}
		}
	}
}";

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0001", "Add circuit breaker to loop", 8, 4);
            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_WhileWithBreakNoBlock_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			while(true)
				break;
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }


        [TestMethod]
        public void CircuitBreakerAnalyzer_ForWithReturn_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			for(int i = i; i < 10;)
			{
				int o = 1;
				return;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_WhileWithNestedBreak_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(i > 1)
			{
				i++;
                if(i > 100)
                {
                    break;
                }
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        #region While condition breaker

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionLessThanIncrementingBreaker_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(i < 1)
			{
				i++;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionLessThanOrEqualsIncrementingBreaker_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(i <= 1)
			{
				i++;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionLessThanDecrementingBreaker_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(i < 1)
			{
				i--;
			}
		}
	}
}";


            var expected = CodeTestHelper.CreateDiagnosticResult("AN0001", 9, 4);

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionLessThanOrEqualsDecrementingBreaker_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(i <= 1)
			{
				i--;
			}
		}
	}
}";


            var expected = CodeTestHelper.CreateDiagnosticResult("AN0001", 9, 4);

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionGreaterThanDecrementingBreaker_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 10;
			while(i > 1)
			{
				i--;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }


        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionGreaterOrEqualsThanDecrementingBreaker_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 10;
			while(i >= 1)
			{
				i--;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionGreaterThanIncrementingBreaker_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 10;
			while(i > 1)
			{
				i++;
			}
		}
	}
}";


            var expected = CodeTestHelper.CreateDiagnosticResult("AN0001", 9, 4);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionGreaterOrEqualsThanIncrementingBreaker_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 10;
			while(i >= 1)
			{
				i++;
			}
		}
	}
}";

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0001", 9, 4);

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionLessThanIncrementingBreakerLeft_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(1 > i)
			{
				i++;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionLessThanOrEqualsIncrementingBreakerLeft_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(1 >= i)
			{
				i++;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionLessThanDecrementingBreakerLeft_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(1 > i)
			{
				i--;
			}
		}
	}
}";


            var expected = CodeTestHelper.CreateDiagnosticResult("AN0001", 9, 4);

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionLessThanOrEqualsDecrementingBreakerLeft_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(1 >= i)
			{
				i--;
			}
		}
	}
}";


            var expected = CodeTestHelper.CreateDiagnosticResult("AN0001", 9, 4);

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionGreaterThanDecrementingBreakerLeft_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 10;
			while(1 < i)
			{
				i--;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }


        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionGreaterOrEqualsThanDecrementingBreakerLeft_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 10;
			while(1 <= i)
			{
				i--;
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionGreaterThanIncrementingBreakerLeft_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 10;
			while(1 < i)
			{
				i++;
			}
		}
	}
}";


            var expected = CodeTestHelper.CreateDiagnosticResult("AN0001", 9, 4);

            VerifyCSharpDiagnostic(test, expected);
        }


        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionGreaterOrEqualsThanIncrementingBreakerLeft_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 10;
			while(1 <= i)
			{
				i++;
			}
		}
	}
}";

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0001", 9, 4);

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionLessThanIncrementingAndOperator_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
            bool run = true;
			int i = 1;
			while(i < 10 && run)
			{
				i++;
			}
		}
	}
}";


            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_ConditionLessThanDecrementingAndOperator_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
            bool run = true;
			int i = 1;
			while(i < 10 && run)
			{
				i--;
			}
		}
	}
}";

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0001", 10, 4);

            VerifyCSharpDiagnostic(test, expected);
        }

        #endregion

        [TestMethod]
        public void CircuitBreakerAnalyzer_WhileWithNestedBreakElse_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(i > 1)
			{
				i++
                if(i < 100)
                {
                    
                }
                else
                {
                    break;
                }
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }


        [TestMethod]
        public void CircuitBreakerAnalyzer_WhileWithDoubleNestedBreak_Ignore()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(i > 1)
			{
				i++
                if(i > 100)
                {
                    if(i > 120)
                    {
                        break;
                    }
                }
			}
		}
	}
}";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_WhileWithDoubleNestedNoBreak_ProposeFix()
        {
            var test = @"
namespace ConsoleApplication1
{
	class TypeName
	{   
		static void Main(string[] args)
		{
			int i = 0;
			while(i > 1)
			{
				i++
                if(i > 100)
                {
                    if(i > 120)
                    {
                        
                    }
                }
			}
		}
	}
}";

            var expected = CodeTestHelper.CreateDiagnosticResult("AN0001", "Add circuit breaker to loop", 9, 4);

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void CircuitBreakerAnalyzer_WhileBreakInIf_Ignore()
        {
            var methodBody = @"
			int i = 0;
			while(i > 1)
			{
				i++
                if(i > 100)
                    break;
			}";
            var code = CodeTestHelper.GetCodeInMainMethod("namespace ConsoleApplication1", methodBody);

            VerifyCSharpDiagnostic(code);
        }


        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return new ConstantFixProvider();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new CircuitBreakerAnalyzer();
        }

    }
}
