using System.Text;

namespace Aoc2022.Day07
{
    internal static class NoSpaceLeftOnDevice
    {
        public static string Solve()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Day 7: No Space Left On Device");
            builder.AppendLine();

            var parser = new Parser();
            var root = parser.Parse();

            builder.AppendLine("Find all of the directories with a total size of at most 100000. What is the sum of the total sizes of those directories?");
            builder.AppendLine($"{FindDirectoriesWithSizeLessOrEqual(root, 100000).Sum(e => e.Size)}");
            builder.AppendLine();

            var free = 30000000 - (70000000 - root.Size);

            builder.AppendLine("Find the smallest directory that, if deleted, would free up enough space on the filesystem to run the update. What is the total size of that directory?");
            builder.AppendLine($"{FindSmallestDirectoryWithSizeGreaterOrEqual(root, free).Size}");
            builder.AppendLine();

            return builder.ToString();
        }

        private static IEnumerable<Directory> FindDirectoriesWithSizeLessOrEqual(Directory root, int size)
        {
            var result = new List<Directory>();

            foreach (var top in root.Directories)
            {
                var queue = new Queue<Directory>();
                
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

        private static Directory FindSmallestDirectoryWithSizeGreaterOrEqual(Directory root, int size)
        {
            Directory result = root;

            foreach (var top in root.Directories)
            {
                var queue = new Queue<Directory>();

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
