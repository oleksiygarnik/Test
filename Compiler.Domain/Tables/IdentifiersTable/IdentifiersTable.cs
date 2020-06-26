using System;
using System.Collections.Generic;

namespace Compiler.Domain.Tables.IdentifiersTable
{
    public class IdentifiersTable : AbstractTable
    {
        public Dictionary<int, Identificator> Identificators { get; set; }
        public int Count { get; set; }
        public IdentifiersTable(string source, string description) : base(source, description)
        {
            Identificators = new Dictionary<int, Identificator>();
        }

        public void AddIdentificator(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            int nextPosition = Count++;

            //!!!!!!!!
            if (!Identificators.TryAdd(nextPosition, null))
                throw new InvalidOperationException("Unsuccess add identificators to table");
        }

        protected override void Loading()
        {
            throw new NotImplementedException();
        }
    }
}
