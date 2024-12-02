namespace Day.Two.RedNosedReports;

public static class PartOne
{
    private static bool IsIncreasing(int[] report)
    {
        for (int i = 0; i < report.Length - 1; i++)
        {
            if (report[i] >= report[i + 1]) return false;

            int difference = report[i + 1] - report[i];
            if (difference is < 1 or > 3) return false;
        }

        return true;
    }

    private static bool IsDecreasing(int[] report)
    {
        for (int i = 0; i < report.Length - 1; i++)
        {
            if (report[i] <= report[i + 1]) return false;

            int difference = report[i] - report[i + 1];
            if (difference is < 1 or > 3) return false;
        }

        return true;
    }

    public static void Run()
    {
        int result = 0;

        int[][] reports = Puzzle.Parse();

        foreach (int[] report in reports)
        {
            if (IsIncreasing(report))
            {
                result++;
                continue;
            }

            if (IsDecreasing(report))
            {
                result++;
            }
        }

        Console.WriteLine($"Day 2, Part 1 : {result}");
    }
}