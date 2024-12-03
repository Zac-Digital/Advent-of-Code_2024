using System.Text.RegularExpressions;

namespace Day.Three.MullItOver;

internal static partial class Puzzle
{
    private const string Input = "";

    internal static List<string> ParsePartOne() =>
        MulExpressionPartOne().Matches(Input).Select(x => x.Value).ToList();

    internal static List<string> ParsePartTwo() =>
        MulExpressionPartTwo().Matches(Input).Select(x => x.Value).ToList();

    [GeneratedRegex(@"mul\(\d{1,3},\d{1,3}\)")]
    private static partial Regex MulExpressionPartOne();

    [GeneratedRegex(@"(do\(\)|don't\(\)|mul\(\d{1,3},\d{1,3}\))")]
    private static partial Regex MulExpressionPartTwo();
}