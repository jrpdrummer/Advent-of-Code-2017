﻿using AdventOfCode2017.Solutions.Extensions;
using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day02
{
    using ParserType = MultiLineStringParser;

    internal class Day2A : IProblem
    {
        private readonly ParserType _parser;

        public Day2A(ParserType parser) { _parser = parser; }

        public Day2A() : this(new ParserType("Day02\\day2.in")) { }

        public virtual string Solve()
        {
            var total = 0;
            foreach (var line in _parser.GetData())
            {
                var numbers = line.ParseDelimitedInts('\t');
                numbers.MinMax(out int min, out int max);
                total += max - min;
            }

            return total.ToString();
        }
    }
}
