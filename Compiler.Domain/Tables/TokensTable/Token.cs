using System;

namespace Compiler.Domain.Tables.TokenTable
{
    public class Token
    {
        public string Value { get; set; }

        public Token(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("message", nameof(value));

            Value = value;
        }

        public override bool Equals(object obj)
            => obj is Token other
                && GetType() == other.GetType()
                && (other.Value.Equals(Value) || ReferenceEquals(this, other));

        public override int GetHashCode()
            => Value.GetHashCode();

        public static bool operator ==(Token firstToken, Token secondToken)
            => firstToken.Equals(secondToken);

        public static bool operator !=(Token firstToken, Token secondToken) 
            => !(firstToken == secondToken);


        public static implicit operator Token(string value) 
            => new Token(value);


        public static implicit operator string(Token token) 
            => token.Value;

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
