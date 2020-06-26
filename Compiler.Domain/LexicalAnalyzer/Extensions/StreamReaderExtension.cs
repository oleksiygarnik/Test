using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Extensions
{
    public static class StreamReaderExtension
    {
        //public static (Status, char?) Next(this StreamReader streamReader)
        //{
        //    int ch = streamReader.Read();

        //    if (ch == -1)
        //        return (Status.EndOfFile, null);
        //    else if (ch == ' ' || ch == 32)
        //        return (Status.EndOfToken, null);
                  

        //    return (Status.Success, Convert.ToChar(ch));
        //}

        public static char? Next(this StreamReader streamReader)
        {
            int ch = streamReader.Read();

            if (ch == -1)
                return null;
            
            return Convert.ToChar(ch);
        }

    }
}
