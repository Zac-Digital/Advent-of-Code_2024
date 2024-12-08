using Shared.Code;

namespace Day.Four.CeresSearch;

public class PartTwo : Compute
{
    public PartTwo() : base("Day 4, Part 2") { }

    protected override int Run()
    {
        int result = 0;

        string[] board = new Puzzle().Parse();

        for (int row = 1; row < board.Length - 1; row++)
        {
            for (int column = 1; column < board[0].Length - 1; column++)
            {
                if (board[row][column] != 'A') continue;

                bool northWestToSouthEast = board[row - 1][column - 1] == 'M' && board[row + 1][column + 1] == 'S';
                bool northEastToSouthWest = board[row - 1][column + 1] == 'M' && board[row + 1][column - 1] == 'S';
                bool southWestToNorthEast = board[row + 1][column - 1] == 'M' && board[row - 1][column + 1] == 'S';
                bool southEastToNorthWest = board[row + 1][column + 1] == 'M' && board[row - 1][column - 1] == 'S';

                if ((northWestToSouthEast || southEastToNorthWest) && (northEastToSouthWest || southWestToNorthEast))
                {
                    result++;
                }
            }
        }

        return result;
    }
}