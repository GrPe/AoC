using AoC2022.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AoC2022;

internal class Day_07
{
    public void Part1()
    {
        var instructions = day_07.data.Split('$', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        FileSystem fileSystem = new();

        foreach (var instruction in instructions)
        {
            var lines = instruction.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            var command = lines[0].Split(' ');

            fileSystem.ExecuteCommand(command.First(), command.Last(), lines.Skip(1).ToArray());
        }

        Console.WriteLine(fileSystem.CalculateSize()); 
    }

    public void Part2()
    {
        var instructions = day_07.data.Split('$', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        FileSystem fileSystem = new();

        foreach (var instruction in instructions)
        {
            var lines = instruction.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            var command = lines[0].Split(' ');

            fileSystem.ExecuteCommand(command.First(), command.Last(), lines.Skip(1).ToArray());
        }

        Console.WriteLine(fileSystem.CleanUp());
    }


    class FileSystem
    {
        private const int AvailableSpace = 70_000_000;
        private const int RequiredFreeSpace = 30_000_000;

        private readonly Directory _mainDirectory;
        private Directory _currentDirectory;

        public FileSystem()
        {
            _mainDirectory = new(null, "/");
            _currentDirectory = _mainDirectory;
        }

        public void ExecuteCommand(string operation, string param, string[] output)
        {
            if (operation == "cd")
            {
                switch (param)
                {
                    case "/":
                        _currentDirectory = _mainDirectory;
                        break;
                    case "..":
                        _currentDirectory = _currentDirectory.Parent;
                        break;
                    default:
                        _currentDirectory = _currentDirectory.GetDirectory(param);
                        break;
                }

                return;
            }

            foreach (var line in output)
            {
                if (line[0] == 'd')
                {
                    _currentDirectory.AppendDirectory(new Directory(_currentDirectory, line.Split(' ')[1]));
                    continue;
                }

                var metadata = line.Split(' ');
                _currentDirectory.AppendFile(new File(_currentDirectory, int.Parse(metadata[0]), metadata[1]));
            }

        }

        public int CalculateSize()
        {
            int totalSum = 0;

            Queue<Directory> queue = new();
            queue.Enqueue(_mainDirectory);

            while (queue.Any())
            {
                var currentDirectory = queue.Peek();
                queue.Dequeue();

                if (currentDirectory.Size <= 100_000)
                {
                    totalSum += currentDirectory.Size;
                }

                foreach(var dir in currentDirectory.GetDirectiories())
                {
                    queue.Enqueue(dir);
                }
            }

            return totalSum;
        }

        public int CleanUp()
        {
            int min = int.MaxValue;

            int currentFreeSpace = AvailableSpace - _mainDirectory.Size;

            Queue<Directory> queue = new();
            queue.Enqueue(_mainDirectory);

            while (queue.Any())
            {
                var currentDirectory = queue.Peek();
                queue.Dequeue();

                if (currentFreeSpace + currentDirectory.Size >= RequiredFreeSpace)
                {
                    min = Math.Min(min, currentDirectory.Size);
                }

                foreach (var dir in currentDirectory.GetDirectiories())
                {
                    queue.Enqueue(dir);
                }
            }

            return min;
        }
    }

    interface Item
    {
        Directory Parent { get; }

        int Size { get; }
        string Name { get; }
    }

    class Directory : Item
    {
        private readonly List<File> _files = new();
        private readonly List<Directory> _directories = new();
        private string _name;

        public Directory(Directory parent, string name)
        {
            Parent = parent;
            _name = name;
        }

        public int Size => _files.Sum(x => x.Size) + _directories.Sum(x => x.Size);
        public string Name => _name;

        public Directory Parent { get; private set; }

        public void AppendFile(File file)
        {
            _files.Add(file);
        }

        public void AppendDirectory(Directory directory)
        {
            _directories.Add(directory);
        }

        public Directory GetDirectory(string name) => _directories.FirstOrDefault(x => x.Name == name);

        public Directory[] GetDirectiories() => _directories.ToArray();
    }

    class File : Item
    {
        private int _size;
        private string _name;

        public File(Directory parent, int size, string fileName)
        {
            Parent = parent;
            _size = size;
            _name = fileName;
        }

        public int Size => _size;

        public string Name => _name;

        public Directory Parent { get; private set; }
    }
}
