namespace Day.Two.RedNosedReports;

internal static class Puzzle
{
    private const string Input = "";

    internal static List<List<int>> Parse() => Input.Split(Environment.NewLine)
        .Select(report => report.Split(" ").Select(int.Parse).ToList()).ToList();
}