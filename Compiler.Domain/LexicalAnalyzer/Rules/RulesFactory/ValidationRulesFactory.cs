using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Rules
{
    public class ValidationRulesFactory
    {
        public static List<IValidationRule> Create(IEnumerable<StateType> stateTypes)
        {
            var rules = new List<IValidationRule>();

            foreach (var stateType in stateTypes)
            {
                switch (stateType)
                {
                    case StateType.Digit:
                        rules.Add(new DigitValidationRule());
                        break;
                    case StateType.Letter:
                        rules.Add(new LetterValidationRule());
                        break;
                    case StateType.Dot:
                        rules.Add(new DotValidationRule());
                        break;
                }
            }

            return rules;
        }
    }
}
