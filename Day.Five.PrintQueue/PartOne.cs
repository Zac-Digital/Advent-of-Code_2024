using Shared.Code;

namespace Day.Five.PrintQueue;

public class PartOne : Compute
{
    private readonly Puzzle _puzzle;

    public PartOne() : base("Day 5, Part 1")
    {
        _puzzle = new Puzzle();
        _puzzle.Parse();
    }

    private bool IsValid(int[] pageNumbers)
    {
        Dictionary<int, int> pageIndexes = new();

        for (int i = 0; i < pageNumbers.Length; i++) pageIndexes[pageNumbers[i]] = i;

        return pageNumbers
            .All(pageNumber => !_puzzle.PageOrderingRules
            .Where(pageOrderingRule => pageOrderingRule[0] == pageNumber)
            .Where(pageOrderingRule => pageIndexes.ContainsKey(pageOrderingRule[1]))
            .Any(pageOrderingRule => pageIndexes[pageNumber] > pageIndexes[pageOrderingRule[1]]));
    }

    protected override int Run()
        => _puzzle.PagesPerUpdate.Where(IsValid).Sum(pageNumbers => pageNumbers[pageNumbers.Length / 2]);
}