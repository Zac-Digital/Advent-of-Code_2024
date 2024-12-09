using Shared.Code;

namespace Day.Six.GuardGallivant;

internal class Puzzle : Puzzle<string[][]>
{
    public override string[][] Parse()
    {
        string[] inputSplit = Input.Split(Environment.NewLine);
        string[][] result = new string[inputSplit.Length][];

        for (int i = 0; i < inputSplit.Length; i++)
        {
            result[i] = inputSplit[i].ToCharArray().Select(x => x.ToString()).ToArray();
        }

        return result;
    }
}