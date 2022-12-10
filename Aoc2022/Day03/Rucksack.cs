namespace Aoc2022.Day03
{
    internal class Rucksack
    {
        public string Contents { get; }

        public string[] Compartments { get; } = new string[2];

        public Rucksack(string contents)
        {
            Contents = contents;

            Compartments[0] = Contents.Substring(0, Contents.Length / 2);
            Compartments[1] = Contents.Substring(Contents.Length / 2);
        }
    }
}
