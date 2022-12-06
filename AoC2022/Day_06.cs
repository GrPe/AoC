using AoC2022.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

internal class Day_06
{
    public void Part1()
    {
        var data = day_06.data;

        for (int i = 3; i < data.Length; i++)
        {
            if (data[i - 3] != data[i - 2] &&
                data[i - 3] != data[i - 1] &&
                data[i - 3] != data[i] &&
                data[i - 2] != data[i - 1] &&
                data[i - 2] != data[i] &&
                data[i - 1] != data[i])
            {
                Console.WriteLine(i + 1);
                return;
            }
        }

        Console.WriteLine("ERROR");
    }

    public void Part2()
    {
        var data = day_06.data;

        Dictionary<char, int> characters = new();
        int counter = 14;

        for (int i = 0; i < data.Length; i++)
        {

            if(counter == 0)
            {
                Console.WriteLine(i);
                return;
            }

            if (!characters.ContainsKey(data[i]))
            {
                characters.Add(data[i], i);
                counter--;
                continue;
            }

            if (i - characters[data[i]] < 14 )
            {
                counter--;
                counter = Math.Max(counter, 14 - (i - characters[data[i]]));
                characters[data[i]] = i;
                continue;
            }

            characters[data[i]] = i;
            counter--;
        }
    }
}
