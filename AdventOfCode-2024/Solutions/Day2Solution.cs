using System.Collections;

namespace AdventOfCode
{
    public class Record
    {
        private IList<int> levels;
        private int processedCount = 0;

        public IList<int> Levels { get => levels; set => levels = value; }
        public int ProcessedCount { get => processedCount; set => processedCount = value; }
    }

    public class Day2Solution : IAdventOfCodeSolution
    {

        private IList<IList<int>> reports = [];

        private IList<Record> records = [];

        public void ParseInput(string input)
        {
            var lines = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            lines
                .Select(l => l.Split(' ', '\r', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse))
                .ToList()
                .ForEach(r =>
                {
                    reports.Add(r.ToList());
                    records.Add(new Record { Levels = r.ToList() });
                });

        }

        public string SolvePart1()
        {
            var safeCount = 0;

            foreach (var report in reports)
            {
                var isValid = true;
                var a = report.ToArray();
                for (int i = 0; i < report.Count - 1; i++)
                {
                    if (
                        (a[i] == a[i + 1]) ||
                        (Math.Abs(a[i] - a[i + 1]) > 3)
                        )
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid && IsMonotonic(a))
                {
                    safeCount++;
                }
            }

            return $"Part 1 = {safeCount}";
        }

        public string SolvePart2()
        {
            var safeCount = 0;


            return $"Part 2 = {safeCount}";
        }

        public (int[] modifiedArray, bool isModified) RemoveInflectionPoint(int[] arr)
        {
            if (arr.Length < 3)
                return (arr, false); // Arrays with less than 3 elements can't have inflections

            List<int> modifiedArray = new List<int>(arr); // Use a list for easier element removal
            bool isModified = false;

            for (int i = 1; i < modifiedArray.Count - 1; i++)
            {
                if ((modifiedArray[i] > modifiedArray[i - 1] && modifiedArray[i] > modifiedArray[i + 1]) ||
                    (modifiedArray[i] < modifiedArray[i - 1] && modifiedArray[i] < modifiedArray[i + 1]))
                {
                    // Found an inflection point, remove the current element
                    modifiedArray.RemoveAt(i);
                    isModified = true;
                    break; // Only remove the first inflection point
                }
            }

            return (modifiedArray.ToArray(), isModified);
        }

        private static bool IsMonotonic(int[] arr)
        {
            if (arr.Length < 2)
                return true; // An array with less than 2 elements is trivially monotonic

            bool isIncreasing = false;
            bool isDecreasing = false;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    isIncreasing = true;
                }
                else if (arr[i] < arr[i - 1])
                {
                    isDecreasing = true;
                }

                // If both increasing and decreasing trends are detected, the array is not monotonic
                if (isIncreasing && isDecreasing)
                {
                    return false;
                }
            }

            return true;
        }


    }
}
