using AoC2022.Data;

namespace AoC2022;

internal class Day_09
{
    public void Part1()
    {
        var movements = day_09.data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        HashSet<Point> points = new();

        Point head = new(0, 0);
        Point tail = new(0, 0);

        points.Add(tail);

        foreach (var movement in movements)
        {
            (var direction, var distance) = (movement.First(), int.Parse(movement[2..]));

            for (int i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case 'U':
                        head.Y++;
                        break;
                    case 'D':
                        head.Y--;
                        break;
                    case 'L':
                        head.X--;
                        break;
                    case 'R':
                        head.X++;
                        break;
                }

                if (tail.DistanceFrom(head) > 1)
                {
                    if (head.X == tail.X) //vertical
                    {
                        tail.Y += head.Y > tail.Y ? 1 : -1;
                    }
                    else if (head.Y == tail.Y) //horizontal
                    {
                        tail.X += head.X > tail.X ? 1 : -1;
                    }
                    else //cross
                    {
                        tail.Y += head.Y > tail.Y ? 1 : -1;
                        tail.X += head.X > tail.X ? 1 : -1;
                    }
                    points.Add(tail);
                }
            }
        }

        Console.WriteLine(points.Count);
    }

    public void Part2()
    {
        var movements = day_09.data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        HashSet<Point> points = new();

        Point head = new(0, 0);
        List<Point> segments = new(){
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
            new(0, 0),
        };

        points.Add(segments.Last());

        foreach (var movement in movements)
        {
            (var direction, var distance) = (movement.First(), int.Parse(movement[2..]));

            for (int i = 0; i < distance; i++)
            {
                switch (direction)
                {
                    case 'U':
                        head.Y++;
                        break;
                    case 'D':
                        head.Y--;
                        break;
                    case 'L':
                        head.X--;
                        break;
                    case 'R':
                        head.X++;
                        break;
                }

                var theTempHead = head;
                for (int s = 0; s < segments.Count; s++)
                {
                    if (segments[s].DistanceFrom(theTempHead) > 1)
                    {
                        if (theTempHead.X == segments[s].X) //vertical
                        {
                            segments[s] = segments[s] with { Y = segments[s].Y + (theTempHead.Y > segments[s].Y ? 1 : -1) };
                        }
                        else if (theTempHead.Y == segments[s].Y) //horizontal
                        {
                            segments[s] = segments[s] with { X = segments[s].X + (theTempHead.X > segments[s].X ? 1 : -1) };
                        }
                        else //cross
                        {
                            segments[s] = segments[s] with { Y = segments[s].Y + (theTempHead.Y > segments[s].Y ? 1 : -1) };
                            segments[s] = segments[s] with { X = segments[s].X + (theTempHead.X > segments[s].X ? 1 : -1) };
                        }
                    }
                    theTempHead = segments[s];
                }

                points.Add(segments.Last());
            }
        }

        Console.WriteLine(points.Count);
    }

    record struct Point(int X, int Y)
    {
        public int DistanceFrom(Point p2)
        {
            return (int)Math.Sqrt(Math.Pow(X - p2.X, 2) + Math.Pow(Y - p2.Y, 2));
        }
    }
}
