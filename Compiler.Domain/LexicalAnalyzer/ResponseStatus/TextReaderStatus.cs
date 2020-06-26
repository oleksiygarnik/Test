using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer.ResponseStatus
{
    public class TextReaderStatus
    {
        public static TextReaderStatus Success => new TextReaderStatus("Success");
        public static TextReaderStatus EndOfFile => new TextReaderStatus("EndOfFile");

        public string Value { get; }

        public TextReaderStatus(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(nameof(value));

            Value = value;
        }
    }
}
