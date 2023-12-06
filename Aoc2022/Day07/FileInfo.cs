namespace Aoc2022.Day07
{
    internal class FileInfo
    {
        public string Name { get; }
        public int Size { get; }
        public DirectoryInfo Parent { get; }

        public FileInfo(string name, int size, DirectoryInfo parent)
        {
            Name = name;
            Size = size;
            Parent = parent;
        }
    }
}
