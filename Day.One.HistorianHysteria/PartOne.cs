namespace Day._1.HistorianHysteria;

public static class PartOne
{
    public static void Run()
    {
        int result = 0;
        (int[] left, int[] right) = Puzzle.Parse();

        for (int i = 0; i < left.Length; i++)
        {
            result += Math.Max(left[i], right[i]) - Math.Min(left[i], right[i]);
        }

        Console.WriteLine(result);
    }
}