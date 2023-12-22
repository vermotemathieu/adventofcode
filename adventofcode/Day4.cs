using Microsoft.VisualBasic;
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
    internal class Day4
    {

        public static int Part1()
        {
            int output = 0;

            var inputText = File.ReadAllText("input/day4.txt");

            List<Day4Card> cards = ParseFile(inputText);


            foreach (var card in cards)
            {
                int score = 0;
                int numbersMatching = card.MyNumbers.Intersect(card.WinningNumbers).Count();

                if(numbersMatching > 0)
                    score++;

                for (int i = 1; i < numbersMatching; i++)
                    score = score + score;

                output += score;
            }



            return output;
        }





        private static List<Day4Card> ParseFile(string input)
        {
            List<Day4Card> cards = new List<Day4Card>();


            var lines = File.ReadAllLines("input/Day4.txt");

            foreach (var line in lines)
            {
                Day4Card card = new Day4Card();

                card.CardNumber = Convert.ToInt32(line.Substring(4, 4).Trim());

                card.WinningNumbers = line.Substring(10, 30).Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
                card.MyNumbers = line.Substring(42, 74).Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();

                cards.Add(card);
            }

            return cards;
        }





        internal class Day4Card
        {
            public int CardNumber { get; set; }

            public List<int> WinningNumbers { get; set; }

            public List<int> MyNumbers { get; set; }


        }
    }
}
