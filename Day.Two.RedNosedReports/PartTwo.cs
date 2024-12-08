using Shared.Code;

namespace Day.Two.RedNosedReports;

public class PartTwo : Compute
{
    public PartTwo() : base("Day 2, Part 2") { }

    private static bool IsIncreasing(List<int> report) => report.SequenceEqual(report.Order());
    private static bool IsDecreasing(List<int> report) => report.SequenceEqual(report.OrderDescending());

    private static bool IsOrdered(List<int> report) => IsIncreasing(report) || IsDecreasing(report);

    private static bool IsInRange(List<int> report)
    {
        for (int i = 0; i < report.Count - 1; i++)
        {
            if (Math.Abs(report[i] - report[i + 1]) is < 1 or > 3) return false;
        }

        return true;
    }

    protected override int Run()
    {
        // Sorry.. Felt like doing something horribly cursed :)
        return new Puzzle().Parse()
            .Count(report =>
                report.Where((_, i) =>
                {
                    List<int> reportWithSkippedIndex = report.Where((_, j) => i != j).ToList();
                    return IsOrdered(reportWithSkippedIndex) && IsInRange(reportWithSkippedIndex);
                }).Any());
    }
}