namespace AoC2021
{
    public class Day_03
    {
        public void Run()
        {
            var data = Data.day_03.data.Split('\n', StringSplitOptions.TrimEntries);

            var reportProcessor = new ReportProcessor(data);

            (int gammaRate, int epsilon) = reportProcessor.ProcessReport();

            Console.WriteLine($"Gamma rate: {gammaRate}; epsilon: {epsilon}; power consumption: {gammaRate * epsilon}");
        }

        public void Run_Part2()
        {
            var data = Data.day_03.data.Split('\n', StringSplitOptions.TrimEntries);

            var reportProcessor = new RatingReportProcessor((int)Math.Pow(2, data[0].Length + 1) - 1);
            foreach (var entry in data)
            {
                reportProcessor.AddValue(entry);
            }

            var oxygen = reportProcessor.FindRating(0, (a, b) => a > b);
            var co2 = reportProcessor.FindRating(0, (a, b) => a <= b);

            Console.WriteLine(Convert.ToInt32(oxygen, 2) * Convert.ToInt32(co2, 2));
        }

        private class ReportProcessor
        {
            private readonly string[] data;
            private int[] numberOfZeros;

            public ReportProcessor(string[] data)
            {
                this.data = data;
                CalculateNumberOfZeros();
            }

            public (int gammaRate, int epsilon) ProcessReport()
            {
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

                return (gammaRate, epsilon);
            }

            private void CalculateNumberOfZeros()
            {
                numberOfZeros = new int[data[0].Length];

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
            }
        }


        public class RatingReportProcessor
        {
            private readonly int[] _leafs;

            public RatingReportProcessor(int size)
            {
                _leafs = new int[size];
            }

            public void AddValue(string value)
            {
                int leaf = 0;
                foreach (var number in value)
                {
                    if (number == '0')
                    {
                        _leafs[leaf]++;
                        leaf = NextLeaf(leaf);
                    }
                    else
                    {
                        _leafs[leaf + 1]++;
                        leaf = NextLeaf(leaf + 1);
                    }
                }
            }

            public string FindRating(int leaf, Func<int, int, bool> comparator)
            {
                if (leaf >= _leafs.Length)
                {
                    return string.Empty;
                }

                if (_leafs[leaf] == 1 && _leafs[leaf + 1] == 0)
                {
                    return "0" + FindRating(NextLeaf(leaf), comparator);
                }
                else if (_leafs[leaf + 1] == 1 && _leafs[leaf] == 0)
                {
                    return "1" + FindRating(NextLeaf(leaf + 1), comparator);
                }

                if (comparator(_leafs[leaf], _leafs[leaf + 1]))
                {
                    return "0" + FindRating(NextLeaf(leaf), comparator);
                }

                return "1" + FindRating(NextLeaf(leaf + 1), comparator);
            }

            private int NextLeaf(int leaf)
            {
                return leaf * 2 + 2;
            }
        }
    }
}
