using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer
{
    //try catch 
    public class TextReader : IDisposable
    {
        public StreamReader reader { get; set; }
        public int CurrentChar { get; set; }
        public bool HasRead { get; set; }
        public TextReader(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentException("message", nameof(source));
                
            reader = new StreamReader(source);
            HasRead = true;
        }

        public void Dispose()
        {
            reader.Dispose();
        }
    }
}
