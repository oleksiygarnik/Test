using Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Extensions;
using Compiler.Compiler.Domain.Tables.LexicalAnalyzer.ResponseStatus;
using Compiler.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer
{
    public class LexicalAnalyzer
    {
        public string Name => GetType().Name;
        
        public string Description => "Lexical analyzer by state diagram";

        public string Source => @"C:\Github\Compiler\Compiler.Domain\Input\input-code.txt";

        public StateDiagram StateDiagram { get; set; }

        public LexicalAnalyzer()
        {
            StateDiagram = new StateDiagram();
        }

       
        public void Analyze()
        {
            try
            {
                using (TextReader textReader = new TextReader(Source))
                {
                    while (!textReader.reader.EndOfStream)
                    {
                        TextReaderResponse status = GetToken(textReader);

                        Console.WriteLine(status);
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("File not found", e);
            }
            
        }

        public TextReaderResponse GetToken(TextReader textReader)
            => StateDiagram.TraversalByRecursion(StateDiagram.GetState(1),"", textReader);
    }
}

