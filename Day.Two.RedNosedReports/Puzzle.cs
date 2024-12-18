using Shared.Code;

namespace Day.Two.RedNosedReports;

internal class Puzzle : Puzzle<List<List<int>>>
{
    public override List<List<int>> Parse() => Input.Split('\n')
        .Select(report => report.Split(" ").Select(int.Parse).ToList()).ToList();
}