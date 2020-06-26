using System;

namespace Compiler.Domain.Tables.Exceptions
{
    [Serializable]
    public class DuplicateTokenException : Exception
    {
        public DuplicateTokenException() { }
        public DuplicateTokenException(string message) : base(message) { }
        public DuplicateTokenException(string message, Exception inner) : base(message, inner) { }
        protected DuplicateTokenException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
 
}
