using Shared.Code;

namespace Day.Four.CeresSearch;

public class PartOne : Compute
{
    public PartOne() : base("Day 4, Part 1") { }

    private static int Walk(string[] board, int row, int column)
    {
        if (board[row][column] != 'X') return 0;

        int rows = board.Length;
        int columns = board[0].Length;

        int count = 0;

        // North
        if (row - 3 >= 0 && board[row - 1][column] == 'M' && board[row - 2][column] == 'A' &&
            board[row - 3][column] == 'S')
        {
            count++;
        }

        // East
        if (column + 3 < columns && board[row][column + 1] == 'M' && board[row][column + 2] == 'A' &&
            board[row][column + 3] == 'S')
        {
            count++;
        }

        // South
        if (row + 3 < rows && board[row + 1][column] == 'M' && board[row + 2][column] == 'A' &&
            board[row + 3][column] == 'S')
        {
            count++;
        }

        // West
        if (column - 3 >= 0 && board[row][column - 1] == 'M' && board[row][column - 2] == 'A' &&
            board[row][column - 3] == 'S')
        {
            count++;
        }

        // North-East
        if (row - 3 >= 0 && column + 3 < columns && board[row - 1][column + 1] == 'M' &&
            board[row - 2][column + 2] == 'A' && board[row - 3][column + 3] == 'S')
        {
            count++;
        }

        // South-East
        if (row + 3 < rows && column + 3 < columns && board[row + 1][column + 1] == 'M' &&
            board[row + 2][column + 2] == 'A' && board[row + 3][column + 3] == 'S')
        {
            count++;
        }

        // North-West
        if (row - 3 >= 0 && column - 3 >= 0 && board[row - 1][column - 1] == 'M' && board[row - 2][column - 2] == 'A' &&
            board[row - 3][column - 3] == 'S')
        {
            count++;
        }

        // South-West
        if (row + 3 < rows && column - 3 >= 0 && board[row + 1][column - 1] == 'M' &&
            board[row + 2][column - 2] == 'A' && board[row + 3][column - 3] == 'S')
        {
            count++;
        }

        return count;
    }

    protected override int Run()
    {
        int result = 0;

        string[] board = new Puzzle().Parse();

        for (int row = 0; row < board.Length; row++)
        {
            for (int column = 0; column < board[0].Length; column++)
            {
                result += Walk(board, row, column);
            }
        }

        return result;
    }
}