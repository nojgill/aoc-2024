using System;
using System.IO;

namespace AdventOfCode
{
    static internal class Program
    {
        static void Main(string[] args)
        {
            // Modify the day number for each day's challenge
            int day = 5;  // Change to the desired day
            var input = GetInput(day);

            Console.WriteLine($"Solving Advent of Code Day {day} challenge...");
            var solver = SolutionFactory.GetSolver(day);
            solver.ParseInput(input);

            var part1Result = solver.SolvePart1();
            Console.WriteLine($"Part 1 - Result: {part1Result}");

            var part2Result = solver.SolvePart2();
            Console.WriteLine($"Part 2 - Result: {part2Result}");
        }

        // Method to get input from a file
        static string GetInput(int day)
        {
            string inputFilePath = $"./input/day{day}.txt"; // Ensure input files are named day1.txt, day2.txt, etc.
            if (File.Exists(inputFilePath))
            {
                return File.ReadAllText(inputFilePath);
            }
            else
            {
                Console.WriteLine("Input file not found!");
                return string.Empty;
            }
        }
    }
}
