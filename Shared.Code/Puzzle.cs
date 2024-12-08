namespace Shared.Code;

public abstract class Puzzle<T>
{
    private static string Read()
    {
        using StreamReader fileReader = new("Puzzle.TXT");
        return fileReader.ReadToEnd();
    }

    protected string Input { get; } = Read();

    public abstract T Parse();
}