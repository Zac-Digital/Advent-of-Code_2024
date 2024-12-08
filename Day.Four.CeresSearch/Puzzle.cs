using Shared.Code;

namespace Day.Four.CeresSearch;

internal class Puzzle : Puzzle<string[]>
{
    public override string[] Parse() => Input.Split(Environment.NewLine);
}