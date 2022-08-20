using System;
using System.Linq;

namespace AdventOfCode.Days;

class Day03 : Day
{
    string[] input;

    public Day03()
    {
        input = SplitInput();
    }

    public override string Solve_1()
    {
        int gamma = 0, epsilon = 0, pow = 0;
        int majority = input.Length / 2;

        for (int i = input[0].Length - 1; i >= 0; i--, pow++)
        {
            var isGammaStrong = input.Select(x => x[i]).Count(x => x == '1') > majority;

            if (isGammaStrong)
            {
                gamma += (int)Math.Pow(2, pow);
            }
            else
            {
                epsilon += (int)Math.Pow(2, pow);
            }
        }

        return (gamma * epsilon).ToString();
    }

    public override string Solve_2()
    {
        return "";
    }
}
