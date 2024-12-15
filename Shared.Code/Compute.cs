using System.Diagnostics;

namespace Shared.Code;

public abstract class Compute
{
    private readonly string _dayPart;

    protected Compute(string dayPart)
    {
        _dayPart = dayPart;
    }

    protected abstract long Run();

    public void Time()
    {
        long result = Run();

        double[] runs = new double[128];

        for (int i = 0; i < runs.Length; i++)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            Run();
            stopWatch.Stop();
            runs[i] = stopWatch.Elapsed.TotalMilliseconds;
        }

        Console.WriteLine($"{_dayPart}: {result}");
        Console.WriteLine($"Elapsed : {runs.Average()}ms");
        Console.WriteLine();
    }
}