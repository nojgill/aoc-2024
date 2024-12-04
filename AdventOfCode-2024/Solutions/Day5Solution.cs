namespace AdventOfCode
{
    public class Day5Solution : IAdventOfCodeSolution
    {
        private IList<string> lines = [];

        public void ParseInput(string input)
        {
            lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

        }

        public string SolvePart1()
        {
            return "";
        }

        public string SolvePart2()
        {
            return "";
        }
    }
}
