namespace Day._1.HistorianHysteria;

public static class PartTwo
{
    public static void Run()
    {
        int result = 0;
        (int[] left, int[] right) = Puzzle.Parse(false);

        foreach (int leftNumber in left)
        {
            result += leftNumber * right.Count(rightNumber => rightNumber == leftNumber);
        }

        Console.WriteLine($"Day 1, Part 2 : {result}");
    }
}