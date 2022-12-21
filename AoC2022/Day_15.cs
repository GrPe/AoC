using AoC2022.Data;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

public class Day_15
{
    public void Part1()
    {
        var beacons = new List<Point>();
        var sensors = new List<Point>();

        foreach (var data in day_15.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries))
        {
            var raw = data.Split('=', ',', ':');
            sensors.Add(new(int.Parse(raw[1]), int.Parse(raw[3])));
            beacons.Add(new(int.Parse(raw[5]), int.Parse(raw[7])));
        }

        const int _requiredY = 2000000;
        const int _size = 5000000;
        bool[] row = new bool[_size * 2];

        foreach (var i in Enumerable.Range(0, sensors.Count))
        {
            var distance = beacons[i].DistanceFrom(sensors[i]);

            var verticalDistance = Math.Abs(_requiredY - sensors[i].Y);
            if (verticalDistance <= distance)
            {
                var diff = (distance - verticalDistance);
                for (int x = _size + sensors[i].X - diff; x < _size + sensors[i].X + diff; x++)
                {
                    row[x] = true;
                }
            }
        }

        Console.WriteLine(row.Count(x => x));
    }

    //Not fully correct - it found 2 points :/
    public void Part2()
    {
        var beacons = new List<Point>();
        var sensors = new List<Point>();

        foreach (var data in day_15.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries))
        {
            var raw = data.Split('=', ',', ':');
            sensors.Add(new(int.Parse(raw[1]), int.Parse(raw[3])));
            beacons.Add(new(int.Parse(raw[5]), int.Parse(raw[7])));
        }

        var tempDistances = new List<int>();

        foreach (int i in Enumerable.Range(0, beacons.Count))
        {
            tempDistances.Add(beacons[i].DistanceFrom(sensors[i]));
        }

        var distances = tempDistances.ToImmutableArray();

        const int _size = 4000000;
        bool[] row = new bool[_size + 1];
        for (int y = 0; y <= _size; y++)
        {
            Array.Clear(row, 0, row.Length);

            foreach (var i in Enumerable.Range(0, sensors.Count))
            {
                var verticalDistance = Math.Abs(y - sensors[i].Y);
                if (verticalDistance <= distances[i])
                {
                    var diff = (distances[i] - verticalDistance);
                    var start = Math.Max(0, sensors[i].X - diff);
                    var end = Math.Min(sensors[i].X + diff, _size + 1);
                    var lenght = end - start;
                    Array.Fill(row, true, start, lenght);
                }
            }

            if (row.Contains(false))
            {
                Console.WriteLine($"y: {y}");
                var sth = row.Where(x => !x).ToList();
                for (int i = 0; i < row.Length; i++)
                {
                    if (!row[i])
                    {
                        Console.WriteLine($"X: {i}");
                    }
                }
                return;
            }

            if (y % 100_000 == 0)
            {
                Console.WriteLine(y);
            }
        }
    }


}

file record Point(int X, int Y)
{
    public int DistanceFrom(Point point) => Math.Abs(X - point.X) + Math.Abs(Y - point.Y);
}

