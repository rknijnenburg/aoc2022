namespace Aoc2022.Day06
{
    internal class Parser
    {
        private readonly string input;

        public Parser()
        {
            input ??= File.ReadAllText("Day06/input.txt");
        }
        
        
        public string Parse()
        {
            return input;
        }


    }
}
