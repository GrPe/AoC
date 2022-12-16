using AoC2022.Data;

namespace AoC2022;

internal class Day_14
{
    public void Part1()
    {
        var rocks = day_14.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        char[,] map = new char[1200, 250];

        foreach (var rock in rocks)
        {
            var points = rock.Split("->", StringSplitOptions.TrimEntries).Select(Point.CreatePoint).ToArray();

            for (int i = 0; i < points.Length - 1; i++)
            {
                var direction = points[i].DirectedTo(points[i + 1]);
                var current = points[i];
                do
                {
                    map[current.X, current.Y] = '#';
                    current += direction;
                }
                while (current != points[i + 1]);
                map[current.X, current.Y] = '#';
            }

        }

        var sand = new Point(500, 0);
        int blockedSandBlocks = 0;
        while (true)
        {
            if (sand.Y > 200)
            {
                break;
            }

            if (map[sand.X, sand.Y + 1] != '\0')
            {
                if (map[sand.X - 1, sand.Y + 1] == '\0')
                {
                    sand = sand with { X = sand.X - 1, Y = sand.Y + 1 };
                }
                else if (map[sand.X + 1, sand.Y + 1] == '\0')
                {
                    sand = sand with { X = sand.X + 1, Y = sand.Y + 1 };
                }
                else
                {
                    map[sand.X, sand.Y] = 'o';
                    sand = new Point(500, 0);
                    blockedSandBlocks++;
                }
                continue;
            }

            sand = sand with { Y = sand.Y + 1};
        }

        Console.WriteLine(blockedSandBlocks);
    }

    public void Part2()
    {
        var rocks = day_14.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        char[,] map = new char[2600, 250];
        int maxY = 0;

        foreach (var rock in rocks)
        {
            var points = rock.Split("->", StringSplitOptions.TrimEntries).Select(Point.CreatePoint).ToArray();

            for (int i = 0; i < points.Length - 1; i++)
            {
                var direction = points[i].DirectedTo(points[i + 1]);
                var current = points[i];
                do
                {
                    map[current.X, current.Y] = '#';
                    current += direction;
                }
                while (current != points[i + 1]);
                map[current.X, current.Y] = '#';
                maxY = Math.Max(maxY, current.Y);
            }

        }

        foreach(var x in Enumerable.Range(0, 1200))
        {
            map[x, maxY + 2] = '#';
        }

        var sand = new Point(500, 0);
        int blockedSandBlocks = 0;
        while (true)
        {

            if (map[sand.X, sand.Y + 1] != '\0')
            {
                if (map[sand.X - 1, sand.Y + 1] == '\0')
                {
                    sand = sand with { X = sand.X - 1, Y = sand.Y + 1 };
                }
                else if (map[sand.X + 1, sand.Y + 1] == '\0')
                {
                    sand = sand with { X = sand.X + 1, Y = sand.Y + 1 };
                }
                else
                {
                    map[sand.X, sand.Y] = 'o';
                    blockedSandBlocks++;

                    if(sand == new Point(500, 0))
                    {
                        break;
                    }

                    sand = new Point(500, 0);
                }
                continue;
            }

            sand = sand with { Y = sand.Y + 1 };
        }

        Console.WriteLine(blockedSandBlocks);
    }

    public record Point(int X, int Y)
    {
        public static Point CreatePoint(string data)
        {
            var splitted = data.Split(',');
            return new Point(int.Parse(splitted[0]), int.Parse(splitted[1]));
        }

        internal Point DirectedTo(Point point)
        {
            if (this.X < point.X)
            {
                return new Point(1, 0);
            }
            else if (this.X > point.X)
            {
                return new Point(-1, 0);
            }
            else if (this.Y < point.Y)
            {
                return new Point(0, 1);
            }
            else if (this.Y > point.Y)
            {
                return new Point(0, -1);
            }
            throw new InvalidOperationException();
        }

        public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
    }

}
