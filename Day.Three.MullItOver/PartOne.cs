using Shared.Code;

namespace Day.Three.MullItOver;

public class PartOne : Compute
{
    public PartOne() : base("Day 3, Part 1") { }

    protected override int Run() => (from instruction in Puzzle.Parse()
        select instruction.Split(',')
        into splitComma
        let nLeft = int.Parse(splitComma[0].Split('(')[1])
        let nRight = int.Parse(splitComma[1].Split(')')[0])
        select nLeft * nRight).Sum();
}