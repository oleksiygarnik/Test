using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Compiler.Domain.Tables.TokenTable
{
    public class TokensTable : AbstractTable
    {
        public Dictionary<int, Token> Tokens { get; set; }

       private XDocument xDocument => XDocument.Load(Source);


        public TokensTable(string source, string description) : base(source, description)
        {
            Tokens = new Dictionary<int, Token>();
            Loading();
        }
        protected override void Loading()
        {
            foreach (XElement tokenElement in xDocument.Element("tokens").Elements("token"))
            {
                XElement codeElement = tokenElement.Element("code");
                XElement valueElement = tokenElement.Element("value");

                int code = int.Parse(codeElement.Value);
                string value = valueElement.Value;
                
                if (!Tokens.TryAdd(code, value))
                    throw new DuplicateTokenException();
            }
        }
    }
}
