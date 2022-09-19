using AoC2021.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021;

internal class Day_04
{

    public void RunPart01()
    {
        var parts = day_04.data.Split("\r\n\r\n");
        var numbers = parts[0].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(x => Convert.ToInt32(x)).ToList();
        var boards = parts[1..].Select(x => new BingoBoard(x)).ToList();

        foreach (var number in numbers)
        {
            foreach (var board in boards)
            {
                board.Marked(number);
                if (board.CheckResult())
                {
                    Console.WriteLine(board.CalculateScore(number));
                    return;
                }
            }
        }
    }

    public void RunPart02()
    {
        var parts = day_04.data.Split("\r\n\r\n");
        var numbers = parts[0].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(x => Convert.ToInt32(x)).ToList();
        var boards = parts[1..].Select(x => new BingoBoard(x)).ToHashSet();

        int number = 0;
        while (boards.Count > 1)
        {
            foreach (var board in boards) board.Marked(numbers[number]);
            boards.RemoveWhere(x => x.CheckResult());
            number++;
        }

        var b = boards.FirstOrDefault();
        for (; number < numbers.Count; number++)
        {
            b.Marked(numbers[number]);
            if(b.CheckResult())
            {
                Console.WriteLine(b.CalculateScore(numbers[number]));
                return;
            }
        }
    }

    public class BingoBoard
    {
        private int[,] _board = new int[5, 5];

        public BingoBoard(string board)
        {
            var data = board.Split(new char[] { ' ', '\n' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToArray();
            for (int i = 0; i < data.Length; i++)
            {
                _board[i / 5, i % 5] = data[i];
            }
        }

        public void Marked(int x)
        {
            for (int i = 0; i < 25; i++)
            {
                if (_board[i / 5, i % 5] == x)
                {
                    _board[i / 5, i % 5] = -1;
                }
            }
        }

        public bool CheckResult()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                bool marked = true;
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j] != -1)
                    {
                        marked = false;
                        break;
                    }
                }
                if (marked) return true;
            }

            for (int j = 0; j < _board.GetLength(0); j++)
            {
                bool marked = true;
                for (int i = 0; i < _board.GetLength(1); i++)
                {
                    if (_board[i, j] != -1)
                    {
                        marked = false;
                        break;
                    }
                }
                if (marked) return true;
            }

            return false;
        }

        public int CalculateScore(int currentNumber)
        {
            int sum = 0;
            foreach (var number in _board)
            {
                sum += number != -1 ? number : 0;
            }

            return sum * currentNumber;
        }
    }
}
