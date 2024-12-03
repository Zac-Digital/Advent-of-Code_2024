using Shared.Code;

namespace Day.Three.MullItOver;

public class PartTwo : Compute
{
    public PartTwo() : base("Day 3, Part 2") { }

    protected override int Run()
    {
        int result = 0;

        bool execute = true;

        foreach (string instruction in Puzzle.ParsePartTwo())
        {
            switch (instruction)
            {
                case "do()":
                    execute = true;
                    break;
                case "don't()":
                    execute = false;
                    break;
                default:
                    if (execute)
                    {
                        string[] splitComma = instruction.Split(',');
                        int nLeft = int.Parse(splitComma[0].Split('(')[1]);
                        int nRight = int.Parse(splitComma[1].Split(')')[0]);
                        result += nLeft * nRight;
                    }
                    break;
            }
        }

        return result;
    }
}