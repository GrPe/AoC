using AoC2021.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;

internal class Day_06
{
    public void RunPart01()
    {
        var fishes = day_06.test.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

        for (int i = 0; i < 256; i++)
        {
            int newFishes = 0;
            for (int j = 0; j < fishes.Count(); j++)
            {
                if (fishes[j] == 0)
                {
                    newFishes++;
                    fishes[j] = 6;
                }
                else
                {
                    fishes[j]--;
                }
            }
            fishes.AddRange(Enumerable.Range(0, newFishes).Select(x => 8));
        }

        Console.WriteLine(fishes.Count);
    }

    public void RunPart02()
    {
        var fishes = day_06.data.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

        long[] fishSet = new long[7];

        foreach (var fish in fishes)
        {
            fishSet[fish]++;
        }

        long[] newFishes = new long[2];
        for (int i = 0; i < 256; i++)
        {
            var f = fishSet[i % 7];
            fishSet[i % 7] += newFishes[i % 2];
            newFishes[i % 2] = f;
        }

        Console.WriteLine(fishSet.Sum() + newFishes.Sum());
    }
}
