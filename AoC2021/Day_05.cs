using AoC2021.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftAntimalwareEngine;
using System.Runtime.InteropServices;

namespace AoC2021;

internal class Day_05
{
    public void RunPart01()
    {
        var data = day_05.data.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();

        Field field = new(1_000, 1_000);

        foreach (var row in CollectionsMarshal.AsSpan(data))
        {
            field.AddVent(new(row));
        }

        Console.WriteLine(field.CountEmergencyPoints());
    }

    public void RunPart02()
    {
        var data = day_05.data.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();

        Field field = new(1_000, 1_000);

        foreach (var row in CollectionsMarshal.AsSpan(data))
        {
            field.AddVent(new(row));
        }

        Console.WriteLine(field.CountEmergencyPoints());
    }

    internal class Field
    {
        private readonly int[,] _field;

        public Field(int x, int y)
        {
            _field = new int[x, y];
        }

        public void AddVent(Vector vent)
        {
            if (vent.IsStraightLine)
            {
                AddStraightVent(vent);
                return;
            }

            AddDiagonalVent(vent);
        }

        public int CountEmergencyPoints()
        {
            int counter = 0;

            foreach (var point in _field)
            {
                if (point >= 2)
                {
                    counter++;
                }
            }

            return counter;
        }

        private void AddStraightVent(Vector vent)
        {
            if (vent.HasSameX)
            {
                if (vent.IsTopToBottom)
                {
                    for (int i = vent.A.Y; i <= vent.B.Y; i++) _field[vent.A.X, i]++;
                }
                else
                {
                    for (int i = vent.B.Y; i <= vent.A.Y; i++) _field[vent.A.X, i]++;
                }
            }
            else if (vent.HasSameY)
            {
                if (vent.IsLeftToRight)
                {
                    for (int i = vent.A.X; i <= vent.B.X; i++) _field[i, vent.A.Y]++;
                }
                else
                {
                    for (int i = vent.B.X; i <= vent.A.X; i++) _field[i, vent.A.Y]++;
                }
            }
        }

        private void AddDiagonalVent(Vector vent)
        {
            if(vent.IsLeftToRight && vent.IsTopToBottom)
            {
                for (int i = vent.A.X, j = vent.A.Y; i <= vent.B.X && j <= vent.B.Y; i++, j++) _field[i, j]++;
            }
            else if(vent.IsLeftToRight)
            {
                for (int i = vent.A.X, j = vent.A.Y; i <= vent.B.X && j >= vent.B.Y; i++, j--) _field[i, j]++;
            }
            else if(vent.IsTopToBottom)
            {
                for (int i = vent.A.X, j = vent.A.Y; i >= vent.B.X && j <= vent.B.Y; i--, j++) _field[i, j]++;
            }
            else
            {
                for (int i = vent.A.X, j = vent.A.Y; i >= vent.B.X && j >= vent.B.Y; i--, j--) _field[i, j]++;
            }
        }
    }

    internal class Vector
    {
        public Point A { get; init; }
        public Point B { get; init; }

        public bool IsStraightLine => A.X == B.X || A.Y == B.Y;
        public bool HasSameX => A.X == B.X;
        public bool HasSameY => A.Y == B.Y;
        public bool IsLeftToRight => A.X < B.X;
        public bool IsTopToBottom => A.Y < B.Y;

        public Vector(string input)
        {
            var rawVector = input.Replace(" -> ", ",").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(x => int.Parse(x)).ToList();

            A = new(rawVector[0], rawVector[1]);
            B = new(rawVector[2], rawVector[3]);
        }
    }

    internal record struct Point(int X, int Y);
}
