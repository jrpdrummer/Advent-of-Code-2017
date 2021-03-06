﻿namespace AdventOfCode2017.Solutions
{
    public class Node<TValue>
    {
        public TValue Value { get; set; }
        public Node<TValue> Next { get; set; }

        public Node() { }

        public Node(TValue value, Node<TValue> next = null)
        {
            Value = value;
            Next = next;
        }
    }
}