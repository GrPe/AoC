using AoC2022.Data;

namespace AoC2022;

internal class Day_04
{
    public void Part1()
    {
        var pairs = day_04.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var result = pairs
            .Select(
            x => PairComparator
                .CheckFullOverlap(x.Split(',', '-')
                .Select(y => int.Parse(y))
                .ToArray()))
            .Sum();

        Console.WriteLine(result);
    }

    public void Part2()
    {
        var pairs = day_04.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var result = pairs
            .Select(
            x => PairComparator
                .CheckAnyOverlap(x.Split(',', '-')
                .Select(y => int.Parse(y))
                .ToArray()))
            .Sum();

        Console.WriteLine(result);
    }

    static class PairComparator
    {
        public static int CheckFullOverlap(int[] sections)
        {
            if (sections[0] <= sections[2] && sections[1] >= sections[3])
            {
                return 1;
            }

            if (sections[2] <= sections[0] && sections[3] >= sections[1])
            {
                return 1;
            }

            return 0;
        }

        public static int CheckAnyOverlap(int[] sections)
        {
            if (sections[0] <= sections[2] && sections[1] >= sections[2])
            {
                return 1;
            }

            if (sections[2] <= sections[0] && sections[3] >= sections[0])
            {
                return 1;
            }

            return 0;
        }
    }
}
