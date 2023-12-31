﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Day1
    {
        public static int Part1()
        {
            var lines = File.ReadAllLines("input/Day1.txt");

            var sum = 0;

            foreach (var line in lines)
            {
                    var digits = line.Where(Char.IsDigit).ToArray();

                    var first = digits[0];
                    var last = digits[digits.Count() - 1];

                    string concat = String.Concat(first, last);

                    sum += Int32.Parse(concat);
            }

            return sum;
        }


        public static int Part2()
        {

            var lines = File.ReadAllLines("input/Day1.txt");

            var sum = 0;


            List<string> ShitToFind = new List<string>();
            ShitToFind.Add("1");
            ShitToFind.Add("2");
            ShitToFind.Add("3");
            ShitToFind.Add("4");
            ShitToFind.Add("5");
            ShitToFind.Add("6");
            ShitToFind.Add("7");
            ShitToFind.Add("8");
            ShitToFind.Add("9");
            ShitToFind.Add("one");
            ShitToFind.Add("two");
            ShitToFind.Add("three");
            ShitToFind.Add("four");
            ShitToFind.Add("five");
            ShitToFind.Add("six");
            ShitToFind.Add("seven");
            ShitToFind.Add("eight");
            ShitToFind.Add("nine");



            foreach (var line in lines)
            {
                SortedDictionary<int, string> shitOccurence = new SortedDictionary<int, string>();

                foreach (var shit in ShitToFind)
                {
                    int minIndex = line.IndexOf(shit);
                    while (minIndex != -1)
                    {
                        string numberValue = shit.Replace("one", "1").Replace("two", "2").Replace("three", "3").Replace("four", "4").Replace("five", "5").Replace("six", "6").Replace("seven", "7").Replace("eight", "8").Replace("nine", "9");
                        shitOccurence.Add(minIndex, numberValue);
                        minIndex = line.IndexOf(shit, minIndex + shit.Length);
                    }
                    shitOccurence.OrderBy(x => x.Key);
                }
                var first = shitOccurence.First().Value;
                var last = shitOccurence.Last().Value;

                string concat = String.Concat(first, last);
                sum += Int32.Parse(concat);
            }
            return sum;

        }
    }
}
