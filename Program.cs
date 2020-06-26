using Compiler.Compiler.Domain.Tables.LexicalAnalyzer;
using Compiler.Domain;
using System;
using System.Collections.Generic;
using System.IO;

namespace Compiler
{
    class Program
    {
        static void Main()
        {
            var lexicalAnalyzer = new LexicalAnalyzer();
            lexicalAnalyzer.Analyze();

            Console.ReadLine();

        }
    }
}
