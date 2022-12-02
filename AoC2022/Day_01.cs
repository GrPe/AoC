using AoC2022.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

internal class Day_01
{
    public void Part1()
    {
        var data = day_01.data.Split("\n\r\n", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var elfs = data.Select(x => new Elf(x.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)));

        Console.WriteLine(elfs.Max(x => x.GetTotalCalories()));
    }

    public void Part2()
    {
        var data = day_01.data.Split("\n\r\n", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var elfs = data.Select(x => new Elf(x.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)));

        Console.WriteLine(elfs.OrderByDescending(x => x.GetTotalCalories()).Take(3).Sum(x => x.GetTotalCalories()));
    }


    public class Elf
    {
        private readonly int[] _backpack;
        private readonly int _sum;

        public Elf(string[] backpack)
        {
            _backpack = backpack.Select(x => int.Parse(x)).ToArray();
            _sum = _backpack.Sum();
        }

        public int GetTotalCalories() => _sum;
    }
}
