using Shared.Code;

namespace Day.Six.GuardGallivant;

public class PartOne : Compute
{
    private static readonly (int, int)[] Direction =
    [
        (-1, 0), // North
        (0, 1),  // East
        (1, 0),  // South
        (0, -1)  // West
    ];

    public PartOne() : base("Day 6, Part 1") { }

    private static (int, int) GetStartPosition(string[][] board)
    {
        for (int row = 0; row < board.Length; row++)
        {
            for (int column = 0; column < board[0].Length; column++)
            {
                if (board[row][column] != "^") continue;

                return (row, column);
            }
        }

        return (-1, -1);
    }

    private static bool Exited(string[][] board, int row, int column) =>
        row <= 0 || row >= board.Length - 1 || column <= 0 || column >= board[0].Length - 1;

    private static int Walk(string[][] board, int rowStart, int columnStart)
    {
        int row = rowStart;
        int column = columnStart;

        string direction = "^";
        (int rowOffset, int columnOffset) = Direction[0];

        while (!Exited(board, row, column))
        {
            string entity = board[row + rowOffset][column + columnOffset];

            if (entity == "#")
            {
                switch (direction)
                {
                    case "^":
                        direction = ">";
                        (rowOffset, columnOffset) = Direction[1];
                        break;
                    case ">":
                        direction = "v";
                        (rowOffset, columnOffset) = Direction[2];
                        break;
                    case "v":
                        direction = "<";
                        (rowOffset, columnOffset) = Direction[3];
                        break;
                    case "<":
                        direction = "^";
                        (rowOffset, columnOffset) = Direction[0];
                        break;
                }
            }

            board[row][column] = "X";

            row += rowOffset;
            column += columnOffset;
        }

        board[row][column] = "X";

        return board.SelectMany(x => x).Count(y => y == "X");
    }

    protected override long Run()
    {
        string[][] board = new Puzzle().Parse();

        (int rowStart, int columnStart) = GetStartPosition(board);

        return Walk(board, rowStart, columnStart);
    }
}