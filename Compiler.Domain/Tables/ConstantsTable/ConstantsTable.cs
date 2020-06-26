using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Domain.Tables.ConstantsTable
{
    public class ConstantsTable : AbstractTable
    {
        public List<Constant> Constants { get; set; }
        public ConstantsTable(string source, string description) : base(source, description)
        {
            Constants = new List<Constant>();
        }
        protected override void Loading()
        {
            throw new NotImplementedException();
        }
    }
}
