using AoC2022.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

internal class Day_05
{
    public void BaseOperation(Action<string, Dictionary<int, Stack<char>>> operation)
    {
        var raw = day_05.data.Split($"{Environment.NewLine}{Environment.NewLine}");
        var (crates, instructions) = (raw[0], raw[1]);

        Dictionary<int, Stack<char>> stacks = new();

        var crateRows = crates
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Reverse()
            .Skip(1);

        foreach (var row in crateRows)
        {
            for (int i = 0; i < row.Length;)
            {
                if (row[i] == '[')
                {
                    var stackNumber = i / 4 + 1;

                    if (!stacks.ContainsKey(stackNumber))
                    {
                        stacks[stackNumber] = new();
                    }

                    stacks[stackNumber].Push(row[i + 1]);
                }

                i += 4;
            }
        }

        foreach (var instruction in instructions.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
        {
            operation(instruction, stacks);
        }

        foreach (var stack in stacks)
        {
            Console.Write(stack.Value.Peek());
        }
        Console.WriteLine();
    }

    public void Part1()
        => BaseOperation((instruction, stacks) =>
        {
            var data = instruction.Split(' ');

            int from = int.Parse(data[3]);
            int to = int.Parse(data[5]);

            for (int i = 0; i < int.Parse(data[1]); i++)
            {
                if (stacks[from].TryPop(out char res))
                {
                    stacks[to].Push(res);
                }
                else
                {
                    continue;
                }
            }
        });

    public void Part2()
        => BaseOperation((instruction, stacks) =>
        {
            var data = instruction.Split(' ');

            int from = int.Parse(data[3]);
            int to = int.Parse(data[5]);

            List<char> swapList = new();
            for (int i = 0; i < int.Parse(data[1]); i++)
            {
                if (stacks[from].TryPop(out char res))
                {
                    swapList.Add(res);
                }
                else
                {
                    continue;
                }
            }

            swapList.Reverse();
            foreach (var item in swapList)
            {
                stacks[to].Push(item);
            }
        });
}
