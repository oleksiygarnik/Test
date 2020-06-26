using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Domain.Tables.ConstantsTable
{
    public class Constant
    {
        public DataType Type { get; set; }

        public string Value { get; set; }

        public Constant(string value, DataType type)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(nameof(value));

            Value = value;
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public override bool Equals(object obj)
        {
            return obj is Identificator other
                && GetType() == other.GetType()
                && (Value.Equals(other.Name) || ReferenceEquals(this, other));
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString()
        {
            return $"{Value} - {Type.Value}";
        }
    }
}
