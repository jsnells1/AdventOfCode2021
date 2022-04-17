using AoCHelper;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    class Day01 : BaseDay
    {
        public readonly int[] input;

        public Day01()
        {
            input = File.ReadAllText(InputFilePath).Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        public override string Solve_1()
        {
            int prev = int.MaxValue;
            int c = 0;

            foreach (int val in input)
            {
                if (val > prev)
                {
                    c++;
                }

                prev = val;
            }

            return c.ToString();
        }

        public override string Solve_2()
        {
            int index = 0;
            int prev = int.MaxValue;
            int c = 0;

            while (index <= input.Length - 3)
            {
                var sum = input[index..(index + 3)].Sum();

                if (sum > prev)
                {
                    c++;
                }

                prev = sum;
                index++;
            }

            return c.ToString();
        }
    }
}
