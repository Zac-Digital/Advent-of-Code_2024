using Shared.Code;

namespace Day.Five.PrintQueue;

public class PartTwo : Compute
{
    private readonly Puzzle _puzzle;

    public PartTwo() : base("Day 5, Part 2")
    {
        _puzzle = new Puzzle();
        _puzzle.Parse();
    }

    private static Dictionary<int, int> GetPageIndexes(int[] pageNumbers)
    {
        Dictionary<int, int> pageIndexes = new();

        for (int i = 0; i < pageNumbers.Length; i++) pageIndexes[pageNumbers[i]] = i;

        return pageIndexes;
    }

    private bool IsValid(int[] pageNumbers)
    {
        Dictionary<int, int> pageIndexes = GetPageIndexes(pageNumbers);

        return pageNumbers
            .All(pageNumber => !_puzzle.PageOrderingRules
                .Where(pageOrderingRule => pageOrderingRule[0] == pageNumber)
                .Where(pageOrderingRule => pageIndexes.ContainsKey(pageOrderingRule[1]))
                .Any(pageOrderingRule => pageIndexes[pageNumber] > pageIndexes[pageOrderingRule[1]]));
    }

    private void Sort(int[] pageNumbers)
    {
        Dictionary<int, int> pageIndexes = GetPageIndexes(pageNumbers);

        for (int i = 0; i < pageNumbers.Length; i++)
        {
            int pageNumber = pageNumbers[i];

            foreach (int[] pageOrderingRule in _puzzle.PageOrderingRules)
            {
                if (pageOrderingRule[1] != pageNumber) continue;
                if (!pageIndexes.ContainsKey(pageOrderingRule[0])) continue;
                if (pageIndexes[pageNumber] > pageIndexes[pageOrderingRule[0]]) continue;

                int swapPageNumber = pageNumbers[pageIndexes[pageOrderingRule[0]]];
                pageNumbers[pageIndexes[pageOrderingRule[0]]] = pageNumber;
                pageNumbers[pageIndexes[pageNumber]] = swapPageNumber;

                return;
            }
        }
    }

    protected override int Run()
    {
        int result = 0;

        foreach (int[] pagePerUpdate in _puzzle.PagesPerUpdate.Where(pagePerUpdate => !IsValid(pagePerUpdate)))
        {
            while (!IsValid(pagePerUpdate))
            {
                Sort(pagePerUpdate);
            }

            result += pagePerUpdate[pagePerUpdate.Length / 2];
        }

        return result;
    }
}