namespace Aoc2022.Day6
{
    internal class Parser
    {
        private string? input = null;

        private void Load()
        {
            input ??= File.ReadAllText("Day6/input.txt");
        }
        
        public string Parse()
        {
            Load();

            return input;
        }


    }
}
