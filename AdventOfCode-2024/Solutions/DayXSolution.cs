namespace AdventOfCode
{
    public class DayXSolution : IAdventOfCodeSolution
    {
        private IList<string> lines = [];

        public void ParseInput(string input)
        {
            lines = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

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
