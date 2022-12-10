namespace Aoc2022.Day07
{
    internal class Directory
    {

        public Directory? Parent { get; }

        public string Name { get; }

        public IEnumerable<Directory> Directories => directories.AsEnumerable();

        private List<Directory> directories = new List<Directory>();

        public IEnumerable<File> Files => files.AsEnumerable();

        private List<File> files = new List<File>();

        public int Size => files.Sum(e => e.Size) + directories.Sum(e => e.Size);

        public Directory(string name, Directory? parent)
        {
            Name = name;
            Parent = parent;
        }

        public Directory GetDirectory(string name)
        {
            return directories.First(e => e.Name == name);
        }
        
        public Directory AddDirectory(string name)
        {
            var directory = new Directory(name, this);

            directories.Add(directory);

            return directory;
        }

        public File AddFile(string name, int size)
        {
            var file = new File(name, size, this);

            files.Add(file);

            return file;
        }
    }
}
