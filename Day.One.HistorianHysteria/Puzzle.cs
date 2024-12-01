using System.Text.RegularExpressions;

namespace Day._1.HistorianHysteria;

internal static partial class Puzzle
{
    private const string Input = "";

    internal static (int[], int[]) Parse()
    {
        string[] numberPairs = Puzzle.Input.Split(Environment.NewLine);

        int[] left = new int[numberPairs.Length];
        int[] right = new int[numberPairs.Length];

        for (int i = 0; i < numberPairs.Length; i++)
        {
            string[] numberPair = ReplaceSpaceRegex().Replace(numberPairs[i], ",").Split(',');

            left[i] = int.Parse(numberPair[0]);
            right[i] = int.Parse(numberPair[1]);
        }

        Array.Sort(left);
        Array.Sort(right);

        return (left, right);
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex ReplaceSpaceRegex();
}