﻿namespace AdventOfCode2017
{
    using System;
    using Solutions.Extensions;
    using Solutions.Problem;

    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine(
                ProblemFactory.Create(ProblemId.Day25A)
                .SendToClipboard()
                .AppendTime()
                .Solve());

            Console.ReadKey();
        }
    }
}
