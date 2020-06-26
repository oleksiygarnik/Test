using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Rules
{
    public class SingleSeparatorValidationRule : IValidationRule
    {
        public bool Validate(char ch)
        {
            return ch == 91 || ch == 93 || ch == 123 || ch == 125 || ch == 40 || ch == 41 ||
                               ch == 44 || ch == 59 || ch == 43 || ch == 45 || ch == 42 || 
                               ch == 47 || ch == 63 || ch == 58;
        }
    }
}
