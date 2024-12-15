using Shared.Code;

namespace Day.One.HistorianHysteria;

public class PartTwo : Compute
{
    public PartTwo() : base("Day 1, Part 2") { }

    protected override long Run()
    {
        int result = 0;
        (int[] left, int[] right) = new Puzzle().Parse();

        foreach (int leftNumber in left)
        {
            result += leftNumber * right.Count(rightNumber => rightNumber == leftNumber);
        }

        return result;
    }
}