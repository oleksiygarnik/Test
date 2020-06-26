using Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Rules;
using Compiler.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer
{
   
    public class Edge
    {
        public State From { get; set; }

        public State To { get; set; }

        public List<StateType> Weights { get; set; }

        public List<IValidationRule> Rules => ValidationRulesFactory.Create(Weights);

        public Edge(State from, State to, StateType weight)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            Weights = new List<StateType>() { weight };
        }

        public Edge(State from, State to, List<StateType> weights)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            Weights = weights ?? throw new ArgumentNullException(nameof(weights));
        }

        public override bool Equals(object obj)
        {
            return obj is Edge other
                && GetType() == other.GetType()
                && ((From.Equals(other.From) && To.Equals(other.To)) || ReferenceEquals(this, other));
        }

        public override int GetHashCode() => HashCode.Combine(From.GetHashCode(), To.GetHashCode());

    }
}
