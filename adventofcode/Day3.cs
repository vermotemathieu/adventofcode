using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Day3
    {

        public static int Part1()
        {
            int output = 0;

            var inputText = File.ReadAllText("input/day3.txt");
            var inputLines = File.ReadAllLines("input/day3.txt");

            foreach (Match match in Regex.Matches(inputText, @"\d+"))
            {

                bool canBeAdded = AdjacentToASymbol(match, inputText, inputLines);

                if (canBeAdded)
                    output += Int32.Parse(match.Value);
            }



            return output;
        }

        private static bool AdjacentToASymbol(Match match, string inputText, string[] inputLines)
        {
            bool result = false;

            long lineNumber = inputText.Substring(0, match.Index).LongCount(chr => chr == '\n');
            int fis = inputText.LastIndexOf("\n", match.Index);
            int posi = match.Index - fis - 1;

            var snippet = new StringBuilder();

            // top
            if (lineNumber > 0)
            {
                snippet.AppendLine(inputLines[lineNumber - 1].Substring((posi == 0) ? 0 : posi - 1, Math.Min(match.Value.Length + 2, 140 - posi + 1)));
            }

            // this line
            snippet.AppendLine(inputLines[lineNumber].Substring((posi == 0) ? 0 : posi - 1, Math.Min(match.Value.Length + 2, 140 - posi + 1)));

            // bottom
            if (lineNumber < inputLines.Length-1)
            {
                snippet.AppendLine(inputLines[lineNumber + 1].Substring((posi == 0) ? 0 : posi - 1, Math.Min(match.Value.Length + 2, 140 - posi + 1)));
            }

            result = ContainsASymbol(snippet.ToString());


            return result;
        }


        private static bool ContainsASymbol(string input)
        {
            // remove whitespace, dots and numbers 
            input = Regex.Replace(input, @"\s+", "");
            input = input.Replace(".", "");
            input = Regex.Replace(input, @"[\d]", string.Empty);


            return (input.Length != 0);
        }

    }
}
