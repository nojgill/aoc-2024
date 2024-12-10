namespace AdventOfCode
{
    public class Day5Solution : IAdventOfCodeSolution
    {
        private readonly IList<Tuple<int, int>> instructions = [];

        private readonly IList<IList<int>> updates = [];
        private readonly Queue<(IList<int> update, Tuple<int, int> rule)> updatesToReorder = [];

        public void ParseInput(string input)
        {
            var lines = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            foreach (var line in lines)
            {
                if (line.Contains('|'))
                {
                    var parts = line.Split('|');

                    if (parts.Length != 2)
                    {
                        throw new ArgumentException("Bad data");
                    }

                    this.instructions.Add(new Tuple<int, int>(int.Parse(parts[0]), int.Parse(parts[1])));
                }
                else
                {
                    this.updates.Add(line.Split(',').Select(p => int.Parse(p)).ToList());
                }
            }
        }

        public string SolvePart1()
        {
            var count = 0;

            foreach (var update in this.updates)
            {
                var (isValid, brokenRule) = this.IsValidUpdate(update);
                if (isValid)
                {
                    // Extract the middle element
                    var middleIndex = update.Count / 2;
                    count += update[middleIndex];
                }
                else
                {
                    this.updatesToReorder.Enqueue((update, brokenRule));
                }
            }

            return $"{count}";
        }

        public string SolvePart2()
        {
            var count = 0;

            while (this.updatesToReorder.Count > 0)
            {
                var (update, rule) = this.updatesToReorder.Dequeue();

                var reordered = Reorder(update, rule);

                var (isValid, brokenRule) = this.IsValidUpdate(reordered.update);

                if (isValid)
                {
                    // Extract the middle element
                    var middleIndex = reordered.update.Count / 2;
                    count += reordered.update[middleIndex];
                }
                else
                {
                    // Pop back on the Q - still screwed
                    this.updatesToReorder.Enqueue((reordered.update, brokenRule));
                }
            }

            return $"{count}";
        }

        private static (IList<int> update, Tuple<int, int> rule) Reorder(IList<int> input, Tuple<int, int> rule)
        {
            var leftIndex = input.IndexOf(rule.Item1);
            var rightIndex = input.IndexOf(rule.Item2);

            input[leftIndex] = rule.Item2;
            input[rightIndex] = rule.Item1;

            return (input, rule);
        }

        private (bool isValid, Tuple<int, int> brokenRule) IsValidUpdate(IList<int> update)
        {
            var isValid = true;
            Tuple<int, int> brokenRule = new(-1, -1);

            foreach (var rule in this.instructions)
            {
                // Both pages present?
                if (update.Contains(rule.Item1) && update.Contains(rule.Item2))
                {
                    var leftIndex = update.IndexOf(rule.Item1);
                    var rightIndex = update.IndexOf(rule.Item2);

                    if (rightIndex < leftIndex)
                    {
                        isValid = false;
                        brokenRule = rule;
                        break;
                    }

                }
            }

            return (isValid, brokenRule);
        }
    }
}
