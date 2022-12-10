namespace Aoc2022.Day06
{
    internal class Parser
    {
        private string? input = null;

        private string Input => input ??= File.ReadAllText("Day06/input.txt");
        
        public string Parse()
        {
            return Input;
        }


    }
}
