using System;
using System.Linq;

namespace Compiler.Domain.Tables
{
    public class DataType
    {
        private const string DataTypes = "int float bool";
        public static DataType Int => new DataType("int");
        public static DataType Float => new DataType("float");
        public static DataType Bool => new DataType("bool");
        public static DataType Unknown => new DataType("unknow");

        public string Value { get; }

        public DataType(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(nameof(value));

            Value = value;
        }

        public static DataType Parse(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!TryParse(value, out var type))
                type = Unknown;
            //throw new FormatException("Data type is not recognized.");

            return type;
        }

        public static bool TryParse(string value, out DataType type)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            string key = value.ToUpperInvariant();

            type = DataTypes.Split(" ").Contains(key)
                ? new DataType(value)
                : null;

            return type != null;
        }

    }
}
