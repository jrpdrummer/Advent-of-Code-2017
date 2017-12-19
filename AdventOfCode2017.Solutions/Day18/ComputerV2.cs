﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode2017.Solutions.Day18
{
    internal class ComputerV2 : Computer
    {
        public int Id { get; }
        public ComputerV2 PairedComputer { get; set; }
        public ulong SendCount { get; set; }

        public bool Waiting => _received.Count < 1 && _lastInstructionWasReceive;

        private readonly Queue<long> _received = new Queue<long>();
        private bool _lastInstructionWasReceive;

        protected override bool Terminate
        {
            get => _lastInstructionWasReceive && _received.Count < 1;
            set => throw new Exception("Liskov Violation!");
        }

        public ComputerV2(IEnumerable<string> instructions, int id) : base(instructions)
        {
            Id = id;
        }

        public override void ExecuteCycle()
        {
            _lastInstructionWasReceive = false;
            base.ExecuteCycle();
        }

        protected override void Rcv(string[] parts)
        {
            _lastInstructionWasReceive = true;
            if (_received.Count > 0)
            {
                var value = _received.Dequeue();
                SetRegister(parts[1], value);
                InstructionPointer++;
            }
        }

        protected override void Snd(string[] parts)
        {
            PairedComputer.QueueValue(GetValue(parts[1]));
            InstructionPointer++;
            SendCount++;

            //Debug.Assert(Id == 0 || SendCount < 10000, "Nope");
        }

        public void QueueValue(long value)
        {
            _received.Enqueue(value);
        }

        public string GetInstruction()
        {
            var sb = new StringBuilder();
            sb.Append($"Program({Id}) - ")
                .Append($"{string.Join(" ", Instructions[InstructionPointer])}")
                .Append('\t')
                .Append($"IP: {InstructionPointer} ");

            return sb.ToString();
        }

        public string GetState()
        {
            var sb = new StringBuilder();

            foreach (var r in Registers)
                sb.Append('\t')
                    .Append($"{r.Key}: {r.Value}");

            sb.AppendLine()
                .Append('\t')
                .Append($"Queued: {string.Join(", ", _received.ToArray())}")
                .AppendLine();

            sb.Append('\t')
                .Append($"Send Count: {SendCount}")
                .AppendLine();

            return sb.ToString();
        }
    }
}