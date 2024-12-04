namespace AdventOfCode
{
    public class Day4Solution : IAdventOfCodeSolution
    {
        private IList<string> lines = [];

        private char[,] wordSearch;

        public void ParseInput(string input)
        {
            lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            this.wordSearch = ConvertToCharArray(lines);
        }

        public string SolvePart1()
        {
            var allLines = new List<string>();

            // Add rows, columns and diagonals
            allLines.AddRange(this.lines);
            allLines.AddRange(GetColumns(wordSearch));
            allLines.AddRange(GetDiagonals(wordSearch, true));
            allLines.AddRange(GetDiagonals(wordSearch, false));

            var count = 0;

            foreach (var line in allLines)
            {
                count += CountSubstringOccurrences(line, "XMAS");
                count += CountSubstringOccurrences(line, "SAMX");
            }

            return $"{count}";
        }

        public string SolvePart2()
        {
            var count = 0;
            var rows = this.wordSearch.GetLength(0);
            var cols = this.wordSearch.GetLength(1);

            for (var row = 0; row < rows - 2; row++)
            {
                for (var col = 0; col < cols - 2; col++)
                {
                    var topLeft = this.wordSearch[row, col];
                    var topRight = this.wordSearch[row, col + 2];
                    var middle = this.wordSearch[row + 1, col + 1];
                    var bottomLeft = this.wordSearch[row + 2, col];
                    var bottomright = this.wordSearch[row + 2, col + 2];

                    if (middle != 'A') continue;

                    var ltor = new string([topLeft, middle, bottomright]);
                    var rtol = new string([topRight, middle, bottomLeft]);

                    if (
                        (ltor.Contains("MAS") || ltor.Contains("SAM")) &&
                        (rtol.Contains("MAS") || rtol.Contains("SAM")))
                    {
                        count++;
                    }
                }
            }

            return $"{count}";
        }

        private static int CountSubstringOccurrences(string text, string substring)
        {
            if (string.IsNullOrEmpty(substring) || string.IsNullOrEmpty(text))
                return 0;

            int count = 0;
            int index = text.IndexOf(substring);

            while (index != -1)
            {
                count++;
                index = text.IndexOf(substring, index + substring.Length);
            }

            return count;
        }


        private static List<string> GetColumns(char[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            List<string> columns = new List<string>();

            for (int col = 0; col < cols; col++)
            {
                string column = "";
                for (int row = 0; row < rows; row++)
                {
                    column += array[row, col];
                }
                columns.Add(column);
            }

            return columns;
        }
        private static List<string> GetDiagonals(char[,] array, bool leftToRight)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            List<string> diagonals = new List<string>();

            // Traverse from top row to the bottom-left edge for diagonals
            for (int k = 0; k < rows; k++)
            {
                string diagonal = "";
                int row = k, col = leftToRight ? 0 : cols - 1;
                while (row < rows && col >= 0 && col < cols)
                {
                    diagonal += array[row, col];
                    row++;
                    col += leftToRight ? 1 : -1;
                }
                diagonals.Add(diagonal);
            }

            // Traverse from leftmost column to the top-right edge for diagonals
            for (int k = 1; k < cols; k++)
            {
                string diagonal = "";
                int row = 0, col = leftToRight ? k : cols - k - 1;
                while (row < rows && col >= 0 && col < cols)
                {
                    diagonal += array[row, col];
                    row++;
                    col += leftToRight ? 1 : -1;
                }
                diagonals.Add(diagonal);
            }

            return diagonals;
        }
        private static char[,] ConvertToCharArray(IList<string> rows)
        {
            int rowCount = rows.Count;
            int colCount = rows[0].Length;
            char[,] array = new char[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    array[i, j] = rows[i][j];
                }
            }

            return array;
        }
    }

}
