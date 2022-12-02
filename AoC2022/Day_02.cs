using AoC2022.Data;

namespace AoC2022;

internal class Day_02
{

    public void Part1()
    {
        var matches = day_02.data.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var result = matches.Select(x => MatchJudge.MakeJudgement(x.Split(' ').First()[0], x.Split(' ').Last()[0])).Sum();
        Console.WriteLine(result);
    }

    public void Part2()
    {
        var matches = day_02.data.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var result = matches.Select(x => MatchJudgeWrapper.MakeJudgement(x.Split(' ').First()[0], x.Split(' ').Last()[0])).Sum();
        Console.WriteLine(result);
    }

    class MatchJudgeWrapper
    {
        public static int MakeJudgement(char a, char b)
        {
            var myChoose = (a, b) switch
            {
                ('A', 'X') => 'Z', //lose
                ('A', 'Z') => 'Y', //win
                ('B', 'X') => 'X', //lose
                ('B', 'Z') => 'Z', //win
                ('C', 'X') => 'Y', //lose
                ('C', 'Z') => 'X', //win
                ('A', 'Y') => 'X', //draft
                ('B', 'Y') => 'Y', //draft
                ('C', 'Y') => 'Z', //draft
                _ => '_'
            };

            return MatchJudge.MakeJudgement(a, myChoose);
        }
    }

    /// <summary>
    /// A/X - Rock
    /// B/Y - Paper
    /// C/Z - Scissors
    /// </summary>
    class MatchJudge
    {
        public static int MakeJudgement(char a, char b)
        {
            if (a == 'A' && b == 'X' ||
                a == 'B' && b == 'Y' ||
                a == 'C' && b == 'Z')
            {
                return 3 + (b) switch
                {
                    'X' => 1,
                    'Y' => 2,
                    'Z' => 3,
                    _ => 0
                };
            }

            if (a == 'A' && b == 'Y')
            {
                return 6 + 2;
            }

            if (a == 'B' && b == 'Z')
            {
                return 6 + 3;
            }

            if (a == 'C' && b == 'X')
            {
                return 6 + 1;
            }

            return (b) switch
            {
                'X' => 1,
                'Y' => 2,
                'Z' => 3,
                _ => 0
            };
        }
    }
}
