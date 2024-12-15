using Shared.Code;

namespace Day.Six.GuardGallivant;

public class PartTwo : Compute
{
    private static readonly (int, int)[] Direction =
    [
        (-1, 0), // North
        (0, 1),  // East
        (1, 0),  // South
        (0, -1)  // West
    ];

    private bool Initial { get; set; } = true;
    private HashSet<(int, int)> Visited { get; } = [];

    public PartTwo() : base("Day 6, Part 2") { }

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

    private int Walk(string[][] board, int rowStart, int columnStart)
    {
        int maxIteration = board.Length * board[0].Length;
        int iteration = 0;

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

                continue;
            }

            row += rowOffset;
            column += columnOffset;

            if (Initial) Visited.Add((row, column));

            if (++iteration == maxIteration) return 1;
        }

        return 0;
    }

    protected override long Run()
    {
        int result = 0;

        string[][] board = new Puzzle().Parse();

        (int rowStart, int columnStart) = GetStartPosition(board);

        Walk(board, rowStart, columnStart);

        Initial = false;

        foreach ((int row, int column) in Visited)
        {
            if (board[row][column] == "^") continue;
            board = new Puzzle().Parse();
            board[row][column] = "#";
            result += Walk(board, rowStart, columnStart);
        }

        return result;
    }
}