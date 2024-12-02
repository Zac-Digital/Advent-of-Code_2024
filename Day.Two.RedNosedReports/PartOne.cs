namespace Day.Two.RedNosedReports;

public static class PartOne
{
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

    public static void Run()
    {
        Console.WriteLine($"Day 2, Part 1 : {Puzzle.Parse().Where(IsOrdered).Count(IsInRange)}");
    }
}