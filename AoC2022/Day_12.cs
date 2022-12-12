using AoC2022.Data;

namespace AoC2022;

internal class Day_12
{
    public void Part1()
    {
        var map = day_12.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries);

        Point startPoint = new(0, 0, 0);
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == 'S')
                {
                    map[i] = map[i].Replace('S', 'a');
                    startPoint = new(i, j, 0);
                    i = map.Length;
                    break;
                }
            }
        }

        bool[,] visited = new bool[map.Length, map[0].Length];
        visited[startPoint.X, startPoint.Y] = true;

        Queue<Point> points = new();
        points.Enqueue(startPoint);

        //int currentDistance = 0;

        while (points.Count > 0)
        {
            Point current = points.Dequeue();

            if (map[current.X][current.Y] == 'E')
            {
                Console.WriteLine(current.Distance);
                break;
            }

            //if (current.Distance > currentDistance)
            //{
            //    currentDistance = current.Distance;
            //    Drawboard(visited);
            //    Console.WriteLine(currentDistance);
            //}

            var distance = current.Distance + 1;

            if (current.X > 0)
            {
                if (map.CanMove(current, current with { X = current.X - 1 }) && !visited[current.X - 1, current.Y])
                {
                    visited[current.X - 1, current.Y] = true;
                    points.Enqueue(new(current.X - 1, current.Y, distance));
                }
            }
            if (current.X < map.Length - 1)
            {
                if (map.CanMove(current, current with { X = current.X + 1 }) && !visited[current.X + 1, current.Y])
                {
                    visited[current.X + 1, current.Y] = true;
                    points.Enqueue(new(current.X + 1, current.Y, distance));
                }
            }
            if (current.Y > 0)
            {
                if (map.CanMove(current, current with { Y = current.Y - 1 }) && !visited[current.X, current.Y - 1])
                {
                    visited[current.X, current.Y - 1] = true;
                    points.Enqueue(new(current.X, current.Y - 1, distance));
                }
            }
            if (current.Y < map[0].Length - 1)
            {
                if (map.CanMove(current, current with { Y = current.Y + 1 }) && !visited[current.X, current.Y + 1])
                {
                    visited[current.X, current.Y + 1] = true;
                    points.Enqueue(new(current.X, current.Y + 1, distance));
                }
            }
        }
    }

    public void Part2()
    {
        var map = day_12.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries);

        Point startPoint = new(0, 0, 0);
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == 'E')
                {
                    map[i] = map[i].Replace('E', 'z');
                    startPoint = new(i, j, 0);
                    i = map.Length;
                    break;
                }
            }
        }

        bool[,] visited = new bool[map.Length, map[0].Length];
        visited[startPoint.X, startPoint.Y] = true;

        Queue<Point> points = new();
        points.Enqueue(startPoint);

        //int currentDistance = 0;

        while (points.Count > 0)
        {
            Point current = points.Dequeue();

            if (map[current.X][current.Y] == 'a')
            {
                Console.WriteLine(current.Distance);
                break;
            }

            //if (current.Distance > currentDistance)
            //{
            //    currentDistance = current.Distance;
            //    Drawboard(visited);
            //    Console.WriteLine(currentDistance);
            //}

            var distance = current.Distance + 1;

            if (current.X > 0)
            {
                if (map.CanMoveDown(current, current with { X = current.X - 1 }) && !visited[current.X - 1, current.Y])
                {
                    visited[current.X - 1, current.Y] = true;
                    points.Enqueue(new(current.X - 1, current.Y, distance));
                }
            }
            if (current.X < map.Length - 1)
            {
                if (map.CanMoveDown(current, current with { X = current.X + 1 }) && !visited[current.X + 1, current.Y])
                {
                    visited[current.X + 1, current.Y] = true;
                    points.Enqueue(new(current.X + 1, current.Y, distance));
                }
            }
            if (current.Y > 0)
            {
                if (map.CanMoveDown(current, current with { Y = current.Y - 1 }) && !visited[current.X, current.Y - 1])
                {
                    visited[current.X, current.Y - 1] = true;
                    points.Enqueue(new(current.X, current.Y - 1, distance));
                }
            }
            if (current.Y < map[0].Length - 1)
            {
                if (map.CanMoveDown(current, current with { Y = current.Y + 1 }) && !visited[current.X, current.Y + 1])
                {
                    visited[current.X, current.Y + 1] = true;
                    points.Enqueue(new(current.X, current.Y + 1, distance));
                }
            }
        }
    }

    private void Drawboard(bool[,] board)
    {
        Console.Clear();
        for(int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(board[i,j] ? 'x' : '.');
            }
            Console.WriteLine();
        }
    }

}

internal static class Ext
{
    public static char GetPointAt(this string[] map, Point point) => map[point.X][point.Y];

    public static bool CanMove(this string[] map, Point point, Point destination)
    {
        var destinationHeigh = (map.GetPointAt(destination) == 'E') ? ('z') : map.GetPointAt(destination);

        var heigh = destinationHeigh - map.GetPointAt(point);
        if (heigh <= 1)
        {
            return true;
        }
        return false;
    }

    public static bool CanMoveDown(this string[] map, Point point, Point destination)
    {
        var heigh = map.GetPointAt(point) - map.GetPointAt(destination);
        if (heigh <= 1)
        {
            return true;
        }
        return false;
    }
}

internal record struct Point(int X, int Y, int Distance);
