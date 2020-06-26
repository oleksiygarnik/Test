using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer
{
    public class State : IComparable<State>
    {
        public int Number { get; set; }

        public bool IsFinish { get; set; }

        public State(int number, bool isFinish = false)
        {
            Number = number;
            IsFinish = isFinish;
        }

        public static implicit operator State(int number) => new State(number);

        public override bool Equals(object obj)
        {
            return obj is State other
                && GetType() == other.GetType()
                && (Number.Equals(other.Number) || ReferenceEquals(other, this));
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public override string ToString()
        {
            return $"Number: {Number}";
        }

        public int CompareTo([AllowNull] State other)
        {
            return Number.CompareTo(other.Number);
        }
    }
}
