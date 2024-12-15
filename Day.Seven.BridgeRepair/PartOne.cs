using Shared.Code;

namespace Day.Seven.BridgeRepair;

public class PartOne : Compute
{
    public PartOne() : base("Day 7, Part 1") { }

    private static long Compute(long[] equation)
    {
        int positions = equation.Length - 2;
        int permutations = (int) Math.Pow(2, positions);

        for (int i = 0; i < permutations; i++)
        {
            long result = equation[1];
            int equationIndex = 2;

            for (int position = positions - 1; position >= 0; position--)
            {
                int bit = (i >> position) & 1;

                if (bit == 0) result += equation[equationIndex];
                else result *= equation[equationIndex];

                equationIndex++;
            }

            if (result == equation[0]) return equation[0];
        }

        return 0;
    }

    protected override long Run()
    {
        return new Puzzle().Parse().AsParallel().Sum(Compute);
    }
}