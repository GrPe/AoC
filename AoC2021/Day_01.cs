using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    [MemoryDiagnoser]
    public class Day_01
    {
        public void Run()
        {
            var data = Data.Data.day_01;

            int increased = 0;

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > data[i - 1])
                {
                    increased++;
                }
            }

            Console.WriteLine($"Increased: {increased} times");
        }

        [Benchmark]
        public void Run_Part2()
        {
            var data = Data.Data.day_01;

            int increased = 0;
            var previousSum = int.MaxValue;
            for(int i = 0; i < data.Length - 2; i++)
            {
                if (data[i] + data[i + 1] + data[i + 2] > previousSum)
                {
                    increased++;
                }

                previousSum = data[i] + data[i + 1] + data[i + 2];
            }

            Console.WriteLine($"Increased: {increased} times");
        }

        [Benchmark]
        public void Run_Part2_Try_2()
        {
            var data = Data.Data.day_01;

            int increased = 0;
            var previousSum = int.MaxValue;
            for (int i = 0; i < data.Length - 2; i++)
            {
                var temp = data[i] + data[i + 1] + data[i + 2];
                if (temp > previousSum)
                {
                    increased++;
                }

                previousSum = temp;
            }

            Console.WriteLine($"Increased: {increased} times");
        }
    }
}
