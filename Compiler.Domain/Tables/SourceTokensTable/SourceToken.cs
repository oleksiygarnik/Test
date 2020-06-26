using Compiler.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.SourceTokensTable
{
    public class SourceToken
    {
        public Token Token { get; set; }

        public int Row { get; set; }

        /// <summary>
        /// Position in row
        /// </summary>
        public int Position { get; set; }

        public SourceToken(Token token, int row, int position)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
            Row = row;
            Position = position;
        }

        public override bool Equals(object obj)
        {
            return obj is SourceToken other
                && GetType() == other.GetType()
                && (Token.Equals(other.Token) || ReferenceEquals(this, other));
        }

        public override int GetHashCode() => Token.GetHashCode();

        public override string ToString() => $"{Token} in {Row} row on {Position} position";

    }
}
