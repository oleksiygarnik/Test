﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Rules
{
    public class WhiteSeparatorValidationRule : IValidationRule
    {
        public bool Validate(char ch)
        {
            return char.IsWhiteSpace(ch) || char.IsControl(ch);
        }
    }
}
