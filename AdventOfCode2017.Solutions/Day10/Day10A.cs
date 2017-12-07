﻿using AdventOfCode2017.Solutions.Parsers;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day10
{
    using ParserType = SingleLineStringParser;

    internal class Day10A : IProblem
    {
        private readonly ParserType _parser;

        public Day10A(ParserType parser)
        {
            _parser = parser;
        }

        public Day10A() : this(new ParserType("Day10\\day10.in"))
        {

        }

        public virtual string Solve()
        {
            return "";
        }
    }
}
