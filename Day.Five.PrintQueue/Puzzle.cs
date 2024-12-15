using Shared.Code;

namespace Day.Five.PrintQueue;

internal class Puzzle : Puzzle<object?>
{
    public List<int[]> PageOrderingRules { get; } = [];
    public List<int[]> PagesPerUpdate { get; } = [];

    public override string[] Parse()
    {
        string[] rulesAndPages = Input.Split('\n');

        char splitChar = '|';

        foreach (string ruleOrPage in rulesAndPages)
        {
            if (string.IsNullOrEmpty(ruleOrPage))
            {
                splitChar = ',';
                continue;
            }

            int[] ruleOrPageSplit = ruleOrPage.Split(splitChar).Select(int.Parse).ToArray();

            if (splitChar == '|')
            {
                PageOrderingRules.Add(ruleOrPageSplit);
            }
            else
            {
                PagesPerUpdate.Add(ruleOrPageSplit);
            }

        }

        return null;
    }
}