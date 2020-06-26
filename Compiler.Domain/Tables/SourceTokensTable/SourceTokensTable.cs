using Compiler.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.SourceTokensTable
{
   
    public class SourceTokensTable 
    {
        private static readonly Lazy<SourceTokensTable> _lazy = 
            new Lazy<SourceTokensTable>(() => new SourceTokensTable());

        public static SourceTokensTable Instance => _lazy.Value;

        public List<SourceToken> SourceTokens { get; set; } 

        private SourceTokensTable()
        {
            SourceTokens = new List<SourceToken>();
        }

    }
}
