namespace AdventOfCode
{
    public class DayXSolution : IAdventOfCodeSolution
    {
        private IList<string> lines = [];

        public void ParseInput(string input)
        {
            lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

        }

        public string SolvePart1()
        {
            return "No solution yet (p1)";
        }

        public string SolvePart2()
        {
            return "No solution yet (p2)";
        }
    }
}
