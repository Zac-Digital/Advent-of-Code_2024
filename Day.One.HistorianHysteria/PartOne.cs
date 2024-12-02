using Shared.Code;

namespace Day.One.HistorianHysteria;

public class PartOne : Compute
{
    public PartOne() : base("Day 1, Part 1") { }

    protected override int Run()
    {
        int result = 0;
        (int[] left, int[] right) = Puzzle.Parse();

        for (int i = 0; i < left.Length; i++)
        {
            result += Math.Max(left[i], right[i]) - Math.Min(left[i], right[i]);
        }

        return result;
    }
}