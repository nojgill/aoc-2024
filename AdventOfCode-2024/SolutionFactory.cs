namespace AdventOfCode
{
    static public class SolutionFactory
    {
        public static IAdventOfCodeSolution GetSolver(int day)
        {
            switch (day)
            {
                case 1:
                    return new Day1Solution();
                case 2:
                    return new Day2Solution();
                case 3:
                    return new Day3Solution();
                case 4:
                    return new Day4Solution();
                case 5:
                    return new Day5Solution();
                default:
                    throw new ArgumentException("Solution for the specified day is not implemented.");
            }
        }
    }
}
