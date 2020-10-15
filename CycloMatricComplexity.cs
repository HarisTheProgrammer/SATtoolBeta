using System.Text.RegularExpressions;


//Class to Calculate Cyclomatic Complexity Using T.Macabe (1972) formula
// M = - N + 2P 
namespace StaticCodeAnalyser
{
    class CycloMatricComplexity
    {
        private readonly string _sourceCode;

        public CycloMatricComplexity(string sourceCode)
        {
            this._sourceCode = sourceCode;
        }
//CYCLOMATIC Calculation
        public int CalculateCyclomaticComplexity()
        {
            const int numberOfConnectedComponentsCoefficient = 2;

            var totalGraphVertices = 0;
            var totalGraphArcs = 0;
            //E (Number of edges)
            var patternOfLoops = @"(\bswitch\b)";
            var matchesInLoops = Regex.Matches(this._sourceCode, patternOfLoops);
            totalGraphVertices += matchesInLoops.Count;
            //N (number of nodes)
            patternOfLoops = @"(\bcase\b)|(\bdefault\b)|(\bfor\b)|(\bforeach\b)|(\bwhile\b)";
            matchesInLoops = Regex.Matches(this._sourceCode, patternOfLoops);
            totalGraphArcs += matchesInLoops.Count;
            // 2P (nodes with exit points)
            patternOfLoops = @"(\bif\b)";
            matchesInLoops = Regex.Matches(this._sourceCode, patternOfLoops);
            totalGraphVertices += matchesInLoops.Count;
            totalGraphArcs += 2 * matchesInLoops.Count;
            //Visualise Vertex Model
            totalGraphVertices++;
            return totalGraphArcs - totalGraphVertices + numberOfConnectedComponentsCoefficient;
        }
    }
}
// A number which is below a complexity level of 10 is generally preferred!)