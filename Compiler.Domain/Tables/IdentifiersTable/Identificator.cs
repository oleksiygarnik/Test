using System;

namespace Compiler.Domain.Tables.IdentifiersTable
{
    public class Identificator
    {
        public string Name { get; set; }

        public DataType Type { get; set; }

        public string Value { get; set; }

        public Identificator(string name, DataType type, string value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(nameof(value));

            Name = name;
            Value = value;
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public override bool Equals(object obj)
        {
            return obj is Identificator other
                && GetType() == other.GetType()
                && (Name.Equals(other.Name) || ReferenceEquals(this, other));
        }

        public override int GetHashCode() => Name.GetHashCode();
    }

}
