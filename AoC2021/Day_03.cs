using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day_03
    {
        public void Run()
        {
            var data = Data.day_03.data.Split('\n', StringSplitOptions.TrimEntries);

            int[] numberOfZeros = CalculateNumberOfZeros(data);

            int gammaRate = 0;
            int epsilon = 0;

            for (int i = numberOfZeros.Length - 1; i >= 0; i--)
            {
                if (numberOfZeros[i] > data.Length / 2)
                {
                    epsilon += (int)Math.Pow(2, numberOfZeros.Length - 1 - i);
                }
                else
                {
                    gammaRate += (int)Math.Pow(2, numberOfZeros.Length - 1 - i);
                }
            }

            Console.WriteLine($"Gamma rate: {gammaRate}; epsilon: {epsilon}; power consumption: {gammaRate * epsilon}");
        }

        private static int[] CalculateNumberOfZeros(string[] data)
        {
            var numberOfZeros = new int[12];

            foreach (var entry in data)
            {
                for (int i = 0; i < entry.Length; i++)
                {
                    if (entry[i] == '0')
                    {
                        numberOfZeros[i]++;
                    }
                }
            }

            return numberOfZeros;
        }
    }
}
