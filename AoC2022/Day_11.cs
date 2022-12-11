using AoC2022.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

internal class Day_11
{
    public void Part1()
    {
        var monkeyData = day_11.data.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var monkeys = monkeyData.Select(x => new Monkey(x)).ToArray();

        foreach (var iteration in Enumerable.Range(1, 20))
        {
            foreach (var monkey in monkeys)
            {
                foreach (var decision in monkey.ThrowItem())
                {
                    monkeys[decision.where].GrabItem(decision.what);
                }
            }
        }

        var result = monkeys.OrderByDescending(x => x.HandledItems).Take(2).Select(x => x.HandledItems).ToArray();
        Console.WriteLine(result[0] * result[1]);
    }

    public void Part2()
    {
        var monkeyData = day_11.data.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var monkeys = monkeyData.Select(x => new Monkey(x, false)).ToArray();

        foreach (var iteration in Enumerable.Range(1, 10000))
        {
            foreach (var monkey in monkeys)
            {
                foreach (var decision in monkey.ThrowItem())
                {
                    monkeys[decision.where].GrabItem(decision.what);
                }
            }
        }

        var result = monkeys.OrderByDescending(x => x.HandledItems).Take(2).Select(x => x.HandledItems).ToArray();
        Console.WriteLine(result[0] * result[1]);
    }

    class Monkey
    {
        private readonly Queue<long> _items = new();
        private Func<long, long> _operation;
        private int _test;
        private int _throwIfTrue;
        private int _throwIfFalse;
        private int _handledItems;
        private bool _isPartOne = true;

        private long _arbitraryBigNum = 9_699_690; // there is all divisible by numbers multiplied  = 13 * 2 * ...

        public Monkey(string input, bool divideManagement = true)
        {
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var items = lines[1].Split(',', ':').Skip(1).Select(long.Parse);
            foreach (var item in items)
            {
                _items.Enqueue(item);
            }

            var operations = lines[2].Split(' ');
            if (operations[4] == "*")
            {
                _operation = (long old) => ((old % _arbitraryBigNum) * (operations[5] == "old" ? (old % _arbitraryBigNum) : (long.Parse(operations[5]) % _arbitraryBigNum))) % _arbitraryBigNum;
            }
            else
            {
                _operation = (long old) => ((old % _arbitraryBigNum) + (operations[5] == "old" ? (old % _arbitraryBigNum) : (long.Parse(operations[5]) % _arbitraryBigNum))) % _arbitraryBigNum;
            }

            _test = int.Parse(lines[3].Split(' ').Last());
            _throwIfTrue = int.Parse(lines[4].Split(' ').Last());
            _throwIfFalse = int.Parse(lines[5].Split(' ').Last());
            _isPartOne = divideManagement;
        }

        public IEnumerable<(long what, long where)> ThrowItem()
        {
            while (true)
            {
                if (_items.Count == 0)
                {
                    yield break;
                }

                var item = _items.Dequeue();
                item = _isPartOne ? (_operation(item) / 3) : _operation(item);
                _handledItems++;

                if (item % _test == 0)
                {
                    yield return (item, _throwIfTrue);
                }
                else
                {
                    yield return (item, _throwIfFalse);
                }
            }
        }

        public void GrabItem(long item)
        {
            _items.Enqueue(item);
        }

        public int HandledItems => _handledItems;
    }
}
