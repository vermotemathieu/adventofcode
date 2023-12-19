using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Day2
    {
        public static int Part1()
        {
            int output = 0;

            List<Day2Game> games = ParseFile("input/day2.txt");

            foreach (var game in games)
            {
                bool nope = false;
                foreach (var set in game.Sets)
                {

                    foreach (var cubes in set.SetsOfCubes)
                    {
                        if (cubes.Color == CubeColor.Red && cubes.NumberOfCubes > 12)
                            nope = true;
                        if (cubes.Color == CubeColor.Green && cubes.NumberOfCubes > 13)
                            nope = true;
                        if (cubes.Color == CubeColor.Blue && cubes.NumberOfCubes > 14)
                            nope = true;
                    }
                }

                if (!nope)
                    output += game.GameNumber;
            }

            return output;
        }
        public static int Part2()
        {
            int output = 0;

            List<Day2Game> games = ParseFile("input/day2.txt");

            foreach (var game in games)
            {
                int maxRed = 0;
                int maxGreen = 0;
                int maxBlue = 0;

                bool nope = false;
                foreach (var set in game.Sets)
                {

                    foreach (var cubes in set.SetsOfCubes)
                    {
                        if (cubes.Color == CubeColor.Red && cubes.NumberOfCubes > maxRed)
                            maxRed = cubes.NumberOfCubes;
                        if (cubes.Color == CubeColor.Green && cubes.NumberOfCubes > maxGreen)
                            maxGreen = cubes.NumberOfCubes;
                        if (cubes.Color == CubeColor.Blue && cubes.NumberOfCubes > maxBlue)
                            maxBlue = cubes.NumberOfCubes;
                    }
                }

                output += (maxRed * maxGreen * maxBlue);
            }

            return output;
        }


        private static List<Day2Game> ParseFile(string input)
        {
            List<Day2Game> games = new List<Day2Game>();


            var lines = File.ReadAllLines("input/Day2.txt");

            foreach (var line in lines)
            {
                Day2Game game = new Day2Game();
                game.GameNumber = Int32.Parse(line.Substring(5, line.IndexOf(":") - 5));

                foreach (var set in line.Substring(line.IndexOf(":") + 1).Split(';'))
                {
                    Day2GameSet day2GameSet = new Day2GameSet();

                    foreach (var cubes in set.Split(','))
                    {
                        Day2SetOfCubes day2SetOfCubes = new Day2SetOfCubes();

                        string cubesnumber = cubes.Replace("red", "").Replace("green", "").Replace("blue", "").Replace(" ", "");

                        if (cubes.Contains("blue"))
                            day2SetOfCubes.Color = CubeColor.Blue;
                        else if (cubes.Contains("green"))
                            day2SetOfCubes.Color = CubeColor.Green;
                        else if (cubes.Contains("red"))
                            day2SetOfCubes.Color = CubeColor.Red;


                        day2SetOfCubes.NumberOfCubes = Int32.Parse(cubesnumber);

                        day2GameSet.SetsOfCubes.Add(day2SetOfCubes);
                    }

                    game.Sets.Add(day2GameSet);
                }
                games.Add(game);
            }

            return games;
        }

    }



    internal class Day2Game
    {
        public int GameNumber { get; set; }

        public List<Day2GameSet> Sets { get; set; }

        public Day2Game()
        {
            Sets = new List<Day2GameSet>();
        }
    }
    internal class Day2GameSet
    {
        public Day2GameSet()
        {
            SetsOfCubes = new List<Day2SetOfCubes>();
        }

        public List<Day2SetOfCubes> SetsOfCubes { get; set; }
    }
    internal class Day2SetOfCubes
    {
        public int NumberOfCubes { get; set; }

        public CubeColor Color { get; set; }
    }


    enum CubeColor
    {
        Blue,
        Red,
        Green
    }
}
