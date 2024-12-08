using System.Text.RegularExpressions;
using Shared.Code;

namespace Day.Three.MullItOver;

internal partial class Puzzle : Puzzle<List<string>>
{
    internal List<string> ParsePartOne() =>
        MulExpressionPartOne().Matches(Input).Select(x => x.Value).ToList();

    internal List<string> ParsePartTwo() =>
        MulExpressionPartTwo().Matches(Input).Select(x => x.Value).ToList();

    [GeneratedRegex(@"mul\(\d{1,3},\d{1,3}\)")]
    private static partial Regex MulExpressionPartOne();

    [GeneratedRegex(@"(do\(\)|don't\(\)|mul\(\d{1,3},\d{1,3}\))")]
    private static partial Regex MulExpressionPartTwo();

    public override List<string> Parse() { return []; }
}