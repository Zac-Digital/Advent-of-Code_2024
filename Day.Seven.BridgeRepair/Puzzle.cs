using Shared.Code;

namespace Day.Seven.BridgeRepair;

internal class Puzzle : Puzzle<long[][]>
{
    public override long[][] Parse()
    {
        string[] inputSplit = Input.Split('\n');
        long[][] output = new long[inputSplit.Length][];

        for (int i = 0; i < inputSplit.Length; i++)
        {
            string[] line = inputSplit[i].Replace(":", "").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            output[i] = line.Select(long.Parse).ToArray();
        }

        return output;
    }
}