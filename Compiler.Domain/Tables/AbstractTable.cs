using System;

namespace Compiler.Domain.Tables
{
    public abstract class AbstractTable 
    {
        public string Name => GetType().Name;
        public string Description { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Source { get; set; }

        public AbstractTable(string source, string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException(nameof(description));
            
            if (string.IsNullOrEmpty(source))
                throw new ArgumentException("message", nameof(source));

            Description = description;
            Source = source;
        }
        protected abstract void Loading();

    }
}
