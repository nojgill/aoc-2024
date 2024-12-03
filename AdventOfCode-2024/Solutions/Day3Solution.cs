using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day3Solution : IAdventOfCodeSolution
    {
        private IList<string> lines = [];
        string raw = string.Empty;

        public void ParseInput(string input)
        {
            lines = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            raw = input;
        }

        public string SolvePart1()
        {
            var sum = 0;
            string reg = @"mul\((\d+),(\d+)\)";

            MatchCollection matches = Regex.Matches(this.raw, reg);

            foreach (Match match in matches)
            {
                sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
            }

            return $"Part 1 = {sum}";
        }

        public string SolvePart2()
        {
            var sum = 0;

            string reg = @"mul\((\d+),(\d+)\)|(do\(\)|don't\(\))";

            MatchCollection matches = Regex.Matches(this.raw, reg);

            var active = true;

            foreach (Match match in matches)
            {
                if (string.IsNullOrEmpty(match.Groups[3].Value) && active)
                {
                    sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                }
                else
                {
                    if (match.Groups[3].Value == "do()")
                    {
                        active = true;
                    }
                    else
                    {
                        active = false;
                    }
                }
            }

            return $"Part 2 = {sum}";
        }
    }
}
