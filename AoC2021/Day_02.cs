using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class Day_02
    {
        public void Run()
        {
            var data = Data.day_02.data
                .Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(x => 
                    { 
                        var temp = x.Split(' ', StringSplitOptions.TrimEntries); 
                        return new Instruction(temp[0], Convert.ToInt32(temp[1])); 
                    })
                .ToArray();

            var submarine = new SubmarinePosition();
            foreach(var instrunction in data)
            {
                submarine.Execute(instrunction);
            }

            Console.WriteLine(submarine.Depth * submarine.Horizontal);
        }

        public void Run_Part2()
        {
            var data = Data.day_02.data
              .Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
              .Select(x =>
              {
                  var temp = x.Split(' ', StringSplitOptions.TrimEntries);
                  return new Instruction(temp[0], Convert.ToInt32(temp[1]));
              })
              .ToArray();

            var submarine = new SubmarinePositionWithManual();
            foreach (var instrunction in data)
            {
                submarine.Execute(instrunction);
            }

            Console.WriteLine(submarine.Depth * submarine.Horizontal);
        }

        public record Instruction(string Direction, int Value);

        public class SubmarinePosition
        {
            public int Horizontal { get; private set; } = 0;
            public int Depth { get; private set; } = 0;

            public void Execute(Instruction instruction)
            {
                if(instruction.Direction == "forward")
                {
                    Horizontal += instruction.Value;
                    return;
                }

                if (instruction.Direction == "down")
                {
                    Depth += instruction.Value;
                    return;
                }

                if(instruction.Direction == "up")
                {
                    Depth -= instruction.Value;
                    return;
                }
            }
        }

        public class SubmarinePositionWithManual
        {
            public int Horizontal { get; private set; } = 0;
            public int Depth { get; private set; } = 0;
            private int aim = 0;

            public void Execute(Instruction instruction)
            {
                if (instruction.Direction == "forward")
                {
                    Horizontal += instruction.Value;
                    Depth += (aim * instruction.Value);
                    return;
                }

                if (instruction.Direction == "down")
                {
                    aim += instruction.Value;
                    return;
                }

                if (instruction.Direction == "up")
                {
                    aim -= instruction.Value;
                    return;
                }
            }
        }
    }
}
