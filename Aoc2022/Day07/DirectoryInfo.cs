namespace Aoc2022.Day07
{
    internal class DirectoryInfo
    {

        public DirectoryInfo? Parent { get; }

        public string Name { get; }

        public IEnumerable<DirectoryInfo> Directories => directories.AsEnumerable();

        private List<DirectoryInfo> directories = new List<DirectoryInfo>();

        public IEnumerable<FileInfo> Files => files.AsEnumerable();

        private List<FileInfo> files = new List<FileInfo>();

        public int Size => files.Sum(e => e.Size) + directories.Sum(e => e.Size);

        public DirectoryInfo(string name, DirectoryInfo? parent)
        {
            Name = name;
            Parent = parent;
        }

        public DirectoryInfo GetDirectory(string name)
        {
            return directories.First(e => e.Name == name);
        }
        
        public DirectoryInfo AddDirectory(string name)
        {
            var directory = new DirectoryInfo(name, this);

            directories.Add(directory);

            return directory;
        }

        public FileInfo AddFile(string name, int size)
        {
            var file = new FileInfo(name, size, this);

            files.Add(file);

            return file;
        }
    }
}
