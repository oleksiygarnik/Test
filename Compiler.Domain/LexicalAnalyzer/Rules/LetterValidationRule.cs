using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Rules
{
    public class LetterValidationRule : IValidationRule
    {
        public bool Validate(char ch)
        {
            return ch >= 97 && ch <= 122;
        }
    }
}
