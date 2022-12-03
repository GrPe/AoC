using AoC2022.Data;
using System.Globalization;

namespace AoC2022;

internal class Day_03
{
    public void Part1()
    {
        var rucksacks = day_03
            .data
            .Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(x => new Rucksack(x));

        var commonItems = rucksacks.Select(x => x.FindCommonItem());

        var result = commonItems.Select(x => PriorityConverter.Convert(x)).Sum();

        Console.WriteLine(result);
    }

    public void Part2()
    {
        var groups = day_03
            .data
            .Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Chunk(3)
            .Select(x => new ElvesGroup(x));

        var commonItems = groups.Select(x => x.FindCommonItem());

        var result = commonItems.Select(x => PriorityConverter.Convert(x)).Sum();

        Console.WriteLine(result);
    }

    static class PriorityConverter
    {
        public static int Convert(char item)
            => item switch
            {
                >= 'a' => item - 'a' + 1,
                >= 'A' => item - 'A' + 27,
                _ => 0
            };
    }

    class Rucksack
    {
        private readonly HashSet<char> _leftItems = new();
        private readonly HashSet<char> _rightItems = new();

        public Rucksack(string content)
        {
            var parts = content.Chunk(content.Length / 2);

            foreach (var item in parts.First())
            {
                _leftItems.Add(item);
            }

            foreach (var item in parts.Last())
            {
                _rightItems.Add(item);
            }
        }

        public char FindCommonItem()
        {
            foreach (var item in _leftItems)
            {
                if (_rightItems.Contains(item))
                {
                    return item;
                }
            }

            return '0';
        }
    }

    class ElvesGroup
    {
        private readonly HashSet<char>[] _rucksacks = new HashSet<char>[3]
        {
            new(),
            new(),
            new()
        };

        public ElvesGroup(string[] content)
        {
            for (int i = 0; i < content.Length; i++)
            {
                foreach(var item in content[i])
                {
                    _rucksacks[i].Add(item);
                }
            }
        }

        public char FindCommonItem()
        {
            List<char> pairCommon = new();

            foreach (var item in _rucksacks[0])
            {
                if (_rucksacks[1].Contains(item))
                {
                    pairCommon.Add(item);
                }
            }

            foreach (var item in pairCommon)
            {
                if (_rucksacks[2].Contains(item))
                {
                    return item;
                }
            }

            return '0';
        }
    }
}
