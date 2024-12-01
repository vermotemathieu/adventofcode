using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode._2024
{
    internal class Day1
    {
        public static int Part1()
        {
            var lines = File.ReadAllLines("2024/input/Day1.txt");

            List<int> lLeft = new List<int>();
            List<int> lRight = new List<int>();


            int cnt = lines.Count();
            foreach (var line in lines)
            {
                var lineArr = line.Split("   ");

                lLeft.Add(Convert.ToInt32(lineArr[0]));
                lRight.Add(Convert.ToInt32(lineArr[1]));
            }

            lLeft.Sort();
            lRight.Sort();


            int totalDistance = 0;

            for (int i = 0; i < lines.Count(); i++)
            {
                var distance = Math.Abs(lLeft[i] - lRight[i]);


                totalDistance += distance;
            }



            return totalDistance;
        }


    }
}
