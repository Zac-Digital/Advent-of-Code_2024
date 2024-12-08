using Shared.Code;

namespace Day.Five.PrintQueue;

internal static class Program
{
    private static readonly Compute[] Code = [new PartOne(), new PartTwo()];

    private static void Main()
    {
        foreach (Compute task in Code)
        {
            task.Time();
        }
    }
}