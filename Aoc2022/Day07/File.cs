namespace Aoc2022.Day07
{
    internal class File
    {
        public string Name { get; }
        public int Size { get; }
        public Directory Parent { get; }

        public File(string name, int size, Directory parent)
        {
            Name = name;
            Size = size;
            Parent = parent;
        }
    }
}
