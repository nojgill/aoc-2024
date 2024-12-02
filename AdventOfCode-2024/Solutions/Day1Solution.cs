namespace AdventOfCode
{
    public class Day1Solution : IAdventOfCodeSolution
{
        private IList<string> lines = [];
        private List<int> listA = [];
        private List<int> listB = [];

        public void ParseInput(string input)
        {
            lines = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

             // Process each line and populate the lists
            lines
                .Select(line => line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse).ToList())
                .Where(numbers => numbers.Count == 2) // Ensure each line has exactly two numbers
                .ToList()
                .ForEach(numbers =>
                {
                    listA.Add(numbers[0]);
                    listB.Add(numbers[1]);
                });

                listA.Sort();
                listB.Sort();
        }

        public string SolvePart1()
        {
            var sum = 0;
            
            for(int i = 0; i < listA.Count; i++)    
            {
                sum += Math.Abs(listA[i]-listB[i]);
            }

            return $"Part 1 = {sum}";
        }

        public string SolvePart2()
        {
            var sim = 0;

            foreach(var lookup in listA)
            {
                var count = listB.FindAll(x => x.Equals(lookup)).Count;
                sim += count*lookup;
            }

            return $"Part 2 = {sim}";
        }
    }
}
