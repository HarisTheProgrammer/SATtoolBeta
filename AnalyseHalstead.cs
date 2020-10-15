using System;
using System.Text.RegularExpressions;

namespace StaticCodeAnalyser
{
    class AnalyseHalstead  //Using Logarithmic calculations, a programmatic complexity calculation can be made.
    {
        private string _sourceCode;
        private string _operators;
        private string _notOperators;
        private int operatorsInTotal;
        private int operandsInTotal;
        private int distinctOperators;
        private int distinctOperands;

        public AnalyseHalstead(string sourceCode)
        {
            this._sourceCode = sourceCode;
        }

        public int getDistinctOperatorsCount() //gather operators
        {
            var operatorsPattern = this._operators;
            var operatorsMatches = Regex.Matches(this._sourceCode, operatorsPattern);
            //Using operator and Operand gather via a counting method
            this.distinctOperators = 0;
            for (var currentMatchCount = 0; currentMatchCount < operatorsMatches.Count; currentMatchCount++)
            {
                var countRepetitiveOperators = 0;
                for (var nextMatchCount = currentMatchCount + 1; nextMatchCount < operatorsMatches.Count; nextMatchCount++)
                {
                    if (operatorsMatches[currentMatchCount].Value != operatorsMatches[nextMatchCount].Value)
                    {
                        continue;
                    }

                    countRepetitiveOperators++; //iterate the number of the same operators
                }

                if (countRepetitiveOperators == 0)
                {
                    this.distinctOperators++;
                }
            }

            return this.distinctOperators; //Return distinct operator count 
        }

        public int getDistinctOperandsCounts() //count operands
        {
            const string replacementCode = " ";

            var operandsPattern = this._notOperators;
            var operandsRegex = new Regex(operandsPattern);
            this._sourceCode = operandsRegex.Replace(this._sourceCode, replacementCode);

            operandsPattern = @"(\b\w+\b)"; //Programmatic expression for a halstead operand pattern - n2 = Number of distinct operands. 

            var operandsMatches = Regex.Matches(this._sourceCode, operandsPattern);

            this.distinctOperands = 0;
            for (var currentMatchCount = 0; currentMatchCount < operandsMatches.Count; currentMatchCount++)
            {
                var countReapeatOperands = 0;
                for (var nextMatchCount = currentMatchCount + 1; nextMatchCount < operandsMatches.Count; nextMatchCount++)
                {
                    if (operandsMatches[currentMatchCount].Value != operandsMatches[nextMatchCount].Value)
                    {
                        continue;
                    }

                    countReapeatOperands++;
                }

                if (countReapeatOperands == 0)
                {
                    this.distinctOperands++;
                }
            }

            return this.distinctOperands;
        }
        //HALSTEAD LOGARITHMS 
        public int getTotalOperatorscount() //aggregate operator count
        {
            var operatorsPattern = @"(\b.*\s\?\s.*\s\:\s.*)"; //Expression for 
            var operatorsMatches = Regex.Matches(this._sourceCode, operatorsPattern);
            this.operatorsInTotal = operatorsMatches.Count;
            this._operators = operatorsPattern + "|";

            operatorsPattern = @"(~)|(\(int\))|(\(float\))|(\(string\))|(\(array\))|(\(object\))|(\(bool\))"; //identify a pattern containing any of the following data types
            operatorsMatches = Regex.Matches(this._sourceCode, operatorsPattern);
            this.operatorsInTotal += operatorsMatches.Count;
            this._operators += operatorsPattern + "|";

            operatorsPattern = @"(\+{1,2})|(\-{1,2})|(\*{1,2})|(\/)|(%)|(\={1,3})|(!=)|(>{1,2})|(<{1,2})|(>=)|(<=)|(<=>)|(\+=)|(\-=)|(\*=)|(\/=)|(%=)|(\*{2}=)|(&{1,2})|(\&{2}=)|(\|{1,2})|(\|{2}=)|(\^)|(~)|(=~)|(\.{1,3})|([\s\S]\,[\s])|(!)|(!~)|({)"; //all input/data types to scan for a pattern
            operatorsMatches = Regex.Matches(this._sourceCode, operatorsPattern);
            this.operatorsInTotal += operatorsMatches.Count;
            this._operators += operatorsPattern + "|";

            operatorsPattern = @"(\bdelete\b)|(\bin\b)|(\binctanceof\b)|(\bnew\b)|(\bthis\b)|(\btypeof\b)|(\bvoid\b)|(\bgoto\b)"; //once it detects a specific input or data type, move onto the next
            operatorsMatches = Regex.Matches(this._sourceCode, operatorsPattern);
            this.operatorsInTotal += operatorsMatches.Count;
            this._operators += operatorsPattern;
            // Using Halstead Length and Volume Logarithm, it can be used to find the unique number of operators and operands within a code snippet)
            return this.operatorsInTotal;
        }
        //Return the total operator count
        public int getTotalOperandsCount()
        {
            const string replacementCode = " "; //function source for building a code improvement suggestor 

            this._notOperators = this._operators;
            this.operandsInTotal = 0; //find operands that are not operands.

            var operandsPattern = @"(\babstract\b)|(\bbreak\b)|(\bchar\b)|(\bcontinue\b)|(\bdo\b)|(\bevent\b)|(\bfinally\b)|(\bforeach\b)|(\bIn\b)|(\binternal\b)|(\bnamespace\b)|(\boperator\b)|(\bparams\b)|(\breadonly\b)|(\bsealed\b)|(\bstatic\b)|(\bthis\b)|(\btypeof\b)|(\bunsafe\b)|(\bvoid\b)|(\bas\b)|(\bbyte\b)|(\bchecked\b)|(\bdecimal\b)|(\bdouble\b)|(\bexplicit\b)|(\bfixed\b)|(\bgoto\b)|(\bin\b)|(\bis\b)|(\bnew\b)|(\bout\b)|(\bprivate\b)|(\bref\b)|(\bshort\b)|(\bstring\b)|(\bstring\b)|(\bstring\b)|(\bstring\b)|(\bstring\b)|(\bstring\b)|(\bstring\b)|(\bstring\b)|(\bstring\b)|(\bthrow\b)|(\buint\b)|(\bushort\b)|(\bvolatile\b)|(\bbase\b)|(\bcase\b)|(\bclass\b)|(\bfloat\b)|(\bif\b)|(\bint\b)|(\block\b)|(\bNull\b)|(\bprotected\b)|(\breturn\b)|(\bsizeof\b)|(\bstruct\b)|(\btrue\b)|(\bbulong\b)|(\busing\b)|(\bwhile\b)|(\bbool\b)|(\bcatch\b)|(\bconst\b)|(\bdelegate\b)|(\benum\b)|(\bfalse\b)|(\bfor\b)|(\bimplicit\b)|(\binterface\b)|(\blong\b)|(\bObject\b)|(\boverride\b)|(\bpublic\b)|(\bsbyte\b)|(\bstackalloc\b)|(\bswitch\b)|(\btry\b)|(\bunchecked\b)|(\bvirtual\b)|(\badd\b)|(\basync\b)|(\bdynamic\b)|(\bglobal\b)|(\bjoin\b)|(\bpartial\b)|(\bselect\b)|(\bvar\b)|(\byield\b)|(\balias\b)|(\bawait\b)|(\bFROM\b)|(\bgroup\b)|(\blet\b)|(\bset\b)|(\bwhere\b)|(\bascending\b)|(\bdescending\b)|(\bdescending\b)|(\binto\b)|(\borderby\b)|(\bremove\b)|(\bvalue\b)";
            this._notOperators += operandsPattern;

            operandsPattern = this._notOperators;
            var operandsRegex = new Regex(operandsPattern);
            this._sourceCode = operandsRegex.Replace(this._sourceCode, replacementCode);

            operandsPattern = @"(\b\w+\b)";
            var matches = Regex.Matches(this._sourceCode, operandsPattern);
            this.operandsInTotal = matches.Count;

            return this.operandsInTotal;
        }
        //CALCULATE STATISTICS, GETTERS FOR EACH HALSTEAD VARIABLE
        public int CalculateProgramVocabulary()
        {
            return (this.distinctOperators + this.distinctOperands);
        }

        public int CalculateProgramLength()
        {
            return (this.operatorsInTotal + this.operandsInTotal);
        }

        public double CalculateTheoreticalProgramLength()
        {
            return (this.distinctOperators * Math.Log(this.distinctOperators, 2) + this.distinctOperands * Math.Log(this.distinctOperands, 2));
        }


        public double CalculateProgramVolume()
        {
            return (this.CalculateProgramLength() * Math.Log(this.CalculateProgramVocabulary(), 2));
        }

        public double CalculateTheoreticalProgramVolume()
        {
            return (this.CalculateTheoreticalProgramLength() * Math.Log(this.CountTheoreticalProgramVocabulary(), 2));
        }
        //Programmatic Vocabulary Calculation
        //This will find the number of unique calls or Parameters within a code block
        //Efforts were not made to add exception handling, as likely code blocks with dependencies would require inputting of entire classes
        //Minor Exception Handling for Pressing Calculation buttons without anything inside the code window
        public int CountTheoreticalProgramVocabulary() //CALCULATE VOCABULARY BASED FROM The total number of unique operator and unique operand occurrences. n = n1 + n2
        {
            var numberOfParameters = 0;

            var functionPattern = @"(\b\w+\b*\(.*\))";
            var callFunctionMatches = Regex.Matches(this._sourceCode, functionPattern);
            var countCalls = callFunctionMatches.Count;

            for (var callCount = 0; callCount < countCalls; callCount++)
            {
                functionPattern = @"(w+)|(\()|(\))|(\,)";
                var defRegex = new Regex(functionPattern);
                var functionMatch = callFunctionMatches[callCount].Value;
                functionMatch = defRegex.Replace(functionMatch, " ");

                functionPattern = @"(\b\w+\b)";
                var parameterMatches = Regex.Matches(functionMatch, functionPattern);
                numberOfParameters += parameterMatches.Count;
            }

            var theoreticalProgramVocabularyResult = numberOfParameters + countCalls;

            return theoreticalProgramVocabularyResult;
        }
        // Convert Data type to a Double, Calculate the Program Quality using the Halstead Log2 N2
        // From this, decude a program quality level, by dividing the program size by the program volume using all of the aforementioned established metrics (operators/operands/theoretical length)
        public double CalculateLevelOfProgrammingQuality()
        {
            return (this.CalculateTheoreticalProgramVolume() / this.CalculateProgramVolume());
        }

        public double CalculateLevelOfProgrammingQualityWithoutTpv() //divide operands by total distinct operators
        {
            return ((2 * this.distinctOperands) / (double)(this.distinctOperators * this.operandsInTotal));
        }

        public double CalculateNumberOfRequiredElementarySolutionsForW() //Elementary solution (Simple funcitons)
        {
            return (this.CalculateTheoreticalProgramLength() * Math.Log(this.CalculateProgramVocabulary() / this.CalculateLevelOfProgrammingQuality())); //Potential length = vocabulary/ Quality
        }

        public double CalculateNumberOfRequiredElementarySolutionsForU() //required solutions = length/vocabulary/quality
        {
            return (this.CalculateProgramLength() * Math.Log(this.CalculateProgramVocabulary() / this.CalculateLevelOfProgrammingQuality()));
        }
    }
}


// TO DO: DIFFICULTY, 
//LANGUAGE LEVEL, 
//PROGRAMMING 
// EFFORT/TIME/ INTELLEGENCE CONTENT