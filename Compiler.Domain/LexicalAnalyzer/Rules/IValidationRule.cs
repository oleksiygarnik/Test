using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Rules
{
    public interface IValidationRule
    {
        bool Validate(char ch);
    }
}
