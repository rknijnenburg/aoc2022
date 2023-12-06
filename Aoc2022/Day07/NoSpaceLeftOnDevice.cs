using Aoc2022.Day08;
using System.Text;

namespace Aoc2022.Day07
{
    internal class NoSpaceLeftOnDevice: IProblem
    {
        public string Name => "No Space Left On Device";
        public int Day => 7;

        private readonly DirectoryInfo root;

        public NoSpaceLeftOnDevice()
        {
            var input = File.ReadAllLines("Day07/input.txt");

            root = new DirectoryInfo("/", null);
            var current = root;
            var command = string.Empty;

            foreach (string line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("$"))
                {
                    command = line.Substring(2);

                    if (command.StartsWith("cd"))
                    {
                        string name = command.Substring(3);

                        if (name == "/")
                        {
                            current = root;
                            continue;
                        }

                        if (name == "..")
                        {
                            current = current.Parent ?? throw new Exception("No parent");
                            continue;
                        }

                        current = current.GetDirectory(name);
                        continue;
                    }

                    if (command.StartsWith("ls"))
                        continue;

                    throw new Exception($"Unhandled command {command}");
                }

                if (command.StartsWith("ls"))
                {
                    if (line.StartsWith("dir"))
                    {
                        current.AddDirectory(line.Substring(4));

                        continue;
                    }

                    var split = line.Split(" ");

                    current.AddFile(split[1], Convert.ToInt32(split[0]));

                    continue;
                }

                throw new Exception($"Unhandled output {command}");
            }
        }

        public string SolvePart1()
        {
            return FindDirectoriesWithSizeLessOrEqual(root, 100000)
                .Sum(e => e.Size)
                .ToString();
        }

        public string SolvePart2()
        {
            var free = 30000000 - (70000000 - root.Size);

            return FindSmallestDirectoryWithSizeGreaterOrEqual(root, free)
                .Size
                .ToString();
        }

        private IEnumerable<DirectoryInfo> FindDirectoriesWithSizeLessOrEqual(DirectoryInfo root, int size)
        {
            var result = new List<DirectoryInfo>();

            foreach (var top in root.Directories)
            {
                var queue = new Queue<DirectoryInfo>();

                queue.Enqueue(top);

                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();

                    if (current.Size <= size)
                        result.Add(current);

                    foreach (var directory in current.Directories)
                        queue.Enqueue(directory);
                }
            }

            return result;
        }

        private DirectoryInfo FindSmallestDirectoryWithSizeGreaterOrEqual(DirectoryInfo root, int size)
        {
            DirectoryInfo result = root;

            foreach (var top in root.Directories)
            {
                var queue = new Queue<DirectoryInfo>();

                queue.Enqueue(top);

                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();

                    if (current.Size < size)
                        continue;

                    if (current.Size < result.Size)
                        result = current;

                    foreach (var directory in current.Directories.Where(e => e.Size >= size))
                        queue.Enqueue(directory);
                }
            }

            return result;
        }
    }
}
