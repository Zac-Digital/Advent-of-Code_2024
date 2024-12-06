﻿using Shared.Code;

namespace Day.Three.MullItOver;

internal static class Program
{
    private static readonly Compute[] Code = [new PartOne(), new PartTwo()];

    private static void Main()
    {
        foreach (Compute Task in Code)
        {
            Task.Time();
        }
    }
}