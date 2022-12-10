using AoC2022.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

internal class Day_10
{
    public void Part1()
    {
        var instructions = day_10.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        Processor processor = new();
        foreach (var instruction in instructions)
        {
            var splitted = instruction.Split(' ');
            processor.Execute(splitted.First(), splitted.Last());
        }

        Console.WriteLine(processor.Signal);
    }

    public void Part2()
    {
        var instructions = day_10.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        Processor processor = new();
        foreach (var instruction in instructions)
        {
            var splitted = instruction.Split(' ');
            processor.Execute(splitted.First(), splitted.Last());
        }

        processor.DrawCrt();
    }

    class Processor
    {
        private int _cycle = 1;
        private int _x = 1;
        private int _signal = 0;
        private bool[] _crt = new bool[240];

        public void Execute(string instruction, string param)
        {
            if (instruction == "noop")
            {
                CheckSignal();
                _cycle++;
                return;
            }

            if (instruction == "addx")
            {
                CheckSignal();
                _cycle++;
                CheckSignal();
                _cycle++;
                _x += int.Parse(param);
                return;
            }
        }

        private void CheckSignal()
        {
            if (_cycle % 40 == 20)
            {
                _signal += _cycle * _x;
            }

            var crtPointer = _cycle - 1;

            if ((_x - 1) == (crtPointer % 40) || _x == (crtPointer % 40) || (_x + 1) == (crtPointer % 40))
            {
                _crt[crtPointer] = true;
            }
        }

        public void DrawCrt()
        {
            for (int i = 0; i < _crt.Length; i++)
            {
                Console.Write(_crt[i] ? '#' : '.');
                if (i % 40 == 39)
                {
                    Console.WriteLine();
                }
            }
        }

        public int Signal => _signal;
    }
}
