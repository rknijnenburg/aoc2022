namespace Aoc2022.Day7
{
    internal class Parser
    {
        private string[]? input = null;

        private void Load()
        {
            input ??= System.IO.File.ReadAllLines("Day7/input.txt");
        }

        public Directory Parse()
        {
            Load();

            var result = new Directory("/", null);
            var current = result;
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
                            current = result;
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
                else
                {
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


            return result;
        }

    }
}
