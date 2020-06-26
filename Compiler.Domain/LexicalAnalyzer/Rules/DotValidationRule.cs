using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Rules
{
    public class DotValidationRule : IValidationRule
    {
        public bool Validate(char ch) => ch == '.';

    }
}
