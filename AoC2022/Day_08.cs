using AoC2022.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

internal class Day_08
{
    public bool[,] Part1()
    {
        var forest = day_08.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        bool[,] visibility = new bool[forest.Length, forest[0].Length];

        int visibleTrees = 0;

        for (int i = 0; i < forest.Length; i++)
        {
            int highestTree = 0;
            for (int j = 0; j < forest[i].Length; j++)
            {
                if (forest[i][j] > highestTree)
                {
                    highestTree = forest[i][j];

                    if (!visibility[i, j])
                    {
                        visibleTrees++;
                    }

                    visibility[i, j] = true;
                }
            }

            highestTree = 0;
            for (int j = forest[i].Length - 1; j >= 0; j--)
            {
                if (forest[i][j] > highestTree)
                {
                    highestTree = forest[i][j];

                    if (!visibility[i, j])
                    {
                        visibleTrees++;
                    }

                    visibility[i, j] = true;
                }
            }
        }

        for (int i = 0; i < forest[0].Length; i++)
        {
            int highestTree = 0;
            for (int j = 0; j < forest.Length; j++)
            {
                if (forest[j][i] > highestTree)
                {
                    highestTree = forest[j][i];

                    if (!visibility[j, i])
                    {
                        visibleTrees++;
                    }

                    visibility[j, i] = true;
                }
            }

            highestTree = 0;
            for (int j = forest.Length - 1; j >= 0; j--)
            {
                if (forest[j][i] > highestTree)
                {
                    highestTree = forest[j][i];

                    if (!visibility[j, i])
                    {
                        visibleTrees++;
                    }

                    visibility[j, i] = true;
                }
            }
        }

        Console.WriteLine(visibleTrees);

        return visibility;
    }

    public void Part2()
    {
        var forest = day_08.data.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var maxScore = 0;
        for (int i = 1; i < forest.Length - 1; i++)
        {
            for (int j = 1; j < forest[i].Length - 1; j++)
            {
                int score = 1;

                int counter = 0;
                for (int x = i + 1; x < forest.Length; x++)
                {
                    counter++;
                    if (forest[x][j] >= forest[i][j]) break;
                }
                score *= counter;
                counter = 0;

                for (int x = i - 1; x >= 0; x--)
                {
                    counter++;
                    if (forest[x][j] >= forest[i][j]) break;
                }
                score *= counter;
                counter = 0;

                for (int x = j - 1; x >= 0; x--)
                {
                    counter++;
                    if (forest[i][x] >= forest[i][j]) break;
                }
                score *= counter;
                counter = 0;

                for (int x = j + 1; x < forest[0].Length; x++)
                {
                    counter++;
                    if (forest[i][x] >= forest[i][j]) break;
                }
                score *= counter;
                maxScore = Math.Max(maxScore, score);
            }
        }

        Console.WriteLine(maxScore);
    }
}
