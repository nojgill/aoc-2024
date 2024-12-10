using System.Data;
using System.Formats.Asn1;

namespace AdventOfCode
{
    public class Day6Solution : IAdventOfCodeSolution
    {
        private IList<string> lines = [];
        private char[,] map;

        private MapPoint startPoint;
        private int rows, cols;

        private readonly IList<char> allowedDirections = ['^', '>', 'v', '<'];

        public void ParseInput(string input)
        {
            lines = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            // Create a 2D char array based on the input dimensions
            this.rows = lines.Count;
            this.cols = lines[0].Length;
            this.map = new char[rows, cols];

            // Populate the 2D array
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.map[i, j] = lines[i][j];

                    if (this.allowedDirections.Contains(lines[i][j]))
                    {
                        this.startPoint = (i, j, lines[i][j]);
                        Console.WriteLine($"Found start point: {this.startPoint}");
                    }
                }
            }
        }

        public string SolvePart1()
        {
            MapPoint current = this.startPoint;
            MapPoint next = this.startPoint;

            while (true)
            {
                //Console.WriteLine($"Current - {current}");
                //Console.WriteLine($"Next - {next}");

                switch (current.Direction)
                {
                    case '^':

                        next.X--;

                        break;

                    case '>':

                        next.Y++;

                        break;

                    case 'v':

                        next.X++;

                        break;

                    case '<':

                        next.Y--;

                        break;
                }

                if (next.X >= cols || next.Y >= rows || next.X < 0 || next.Y < 0)
                {
                    // Mark this one
                    this.map[current.X, current.Y] = 'X';

                    // We're done
                    break;
                }

                if (this.map[next.X, next.Y] == '#')
                {
                    // Hit a blocker, change direction
                    Console.WriteLine("Change Direction");

                    var index = this.allowedDirections.IndexOf(current.Direction);

                    if (++index > 3)
                    {
                        index = 0;
                    }

                    current.Direction = this.allowedDirections[index];
                    next = current;
                }
                else
                {
                    // Mark this one
                    this.map[current.X, current.Y] = 'X';

                    // Move on
                    current = next;
                }
            }

            return $"{CountOccurrences(this.map, 'X')}";
        }

        public string SolvePart2()
        {
            return $"";
        }


        static int CountOccurrences(char[,] array, char target)
        {
            int count = 0;

            for (int i = 0; i < array.GetLength(0); i++) // Rows
            {
                for (int j = 0; j < array.GetLength(1); j++) // Columns
                {
                    if (array[i, j] == target)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }

    internal record struct MapPoint(int X, int Y, char Direction)
    {
        public static implicit operator (int x, int y, char direction)(MapPoint value)
        {
            return (value.X, value.Y, value.Direction);
        }

        public static implicit operator MapPoint((int x, int y, char direction) value)
        {
            return new MapPoint(value.x, value.y, value.direction);
        }
    }
}
