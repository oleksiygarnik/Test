using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Extensions
{
    public static class StringExtension
    {
        public static string FirstLetterToUpper(this string str)
        {
            return str.Length > 0
                ? char.ToUpper(str[0]) + str.Substring(1)
                : "";
        }
    }
}
