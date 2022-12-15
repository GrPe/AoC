using AoC2022.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AoC2022;

internal class Day_13
{
    public void Part1()
    {
        var pairs = day_13.data.Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        int sum = 0;
        int counter = 1;
        foreach (var pair in pairs)
        {
            var packages = pair.Split(Environment.NewLine);

            var firstPackage = JArray.Parse(packages[0]);
            var secondPackage = JArray.Parse(packages[1]);

            var result = CompareElement(firstPackage, secondPackage);

            if(result == Result.RightOrder)
            {
                sum += counter;
            }
            counter++;
        }

        Console.WriteLine(sum);
    }

    public void Part2()
    {
        var fulldata = day_13.data + "\r\n[[2]]\r\n[[6]]";
        var lines = fulldata.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var packages = lines.Select(x =>JArray.Parse(x));
        var orderer = packages.OrderBy(x => x, new PackageComparer()).ToArray();

        var first = Array.FindIndex(orderer, 0, orderer.Length, x => x.ToString() == JArray.Parse("[[2]]").ToString()) + 1;
        var second = Array.FindIndex(orderer, 0, orderer.Length, x => x.ToString() == JArray.Parse("[[6]]").ToString()) + 1;

        Console.WriteLine(first * second);
    }

    internal static Result CompareElement(JToken first, JToken second)
    {
        if (first.Type == JTokenType.Integer && second.Type == JTokenType.Integer)
        {
            (int firstElement, int secondElement) = ((int)first, (int)second);

            if (firstElement < secondElement)
            {
                return Result.RightOrder;
            }

            if (firstElement > secondElement)
            {
                return Result.NotRightOrder;
            }

            return Result.Continue;
        }

        if (first.Type == JTokenType.Array && second.Type == JTokenType.Array)
        {
            for (int i = 0; i < first.Count() && i < second.Count(); i++)
            {
                var result = CompareElement(first[i]!, second[i]!);
                if (result != Result.Continue)
                {
                    return result;
                }
            }

            if (first.Count() < second.Count())
            {
                return Result.RightOrder;
            }
            if (first.Count() > second.Count())
            {
                return Result.NotRightOrder;

            }
            return Result.Continue;
        }

        if (first.Type == JTokenType.Integer)
        {
            return CompareElement(JArray.FromObject(new List<JToken> { first }), second);
        }
        else
        {
            return CompareElement(first, JArray.FromObject(new List<JToken> { second }));
        }
    }

    class PackageComparer : IComparer<JToken>
    {
        public int Compare(JToken? x, JToken? y)
        {
            var result = CompareElement(x, y);

            return result switch
            {
                Result.RightOrder => -1,
                Result.NotRightOrder => 1,
                Result.Continue => 0
            };
        }
    }

    internal enum Result
    {
        RightOrder,
        NotRightOrder,
        Continue
    }
}