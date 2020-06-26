using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Rules
{
    public class DigitValidationRule : IValidationRule
    {
        public bool Validate(char ch)
        {
            return ch >= 48 && ch <= 57;
        }
    }
}

