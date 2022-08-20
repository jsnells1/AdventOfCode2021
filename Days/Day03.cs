using System;
using System.Collections.Generic;
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
            var isGammaStrong = input.Count(x => x[i] == '1') > majority;

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
        var oxygenList = input.ToList();
        var co2List = input.ToList();

        for (int i = 0; i < input[0].Length; i++)
        {
            var reducedOxygen = reduceList(oxygenList, i, true, '1');
            var reducedCo2 = reduceList(co2List, i, false, '0');

            if (!reducedCo2 && !reducedOxygen)
            {
                break;
            }
        }

        return (Convert.ToInt32(oxygenList[0], 2) * Convert.ToInt32(co2List[0], 2)).ToString();
    }

    private bool reduceList(List<string> list, int i, bool mostCommon, char tieBreaker)
    {
        if (list.Count == 1)
        {
            return false;
        }

        var majority = list.Count / 2.0;
        var positiveBits = list.Count(x => x[i] == '1');
        char filter;

        if (positiveBits == majority)
        {
            filter = tieBreaker;
        }
        else if (mostCommon)
        {
            filter = (positiveBits > majority) ? '1' : '0';
        }
        else
        {
            filter = (positiveBits > majority) ? '0' : '1';

        }

        list.RemoveAll(x => x[i] != filter);
        return true;
    }
}
