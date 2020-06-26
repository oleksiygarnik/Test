using Compiler.Compiler.Domain.Tables.LexicalAnalyzer.Extensions;
using Compiler.Compiler.Domain.Tables.LexicalAnalyzer.ResponseStatus;
using Compiler.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Compiler.Compiler.Domain.Tables.LexicalAnalyzer
{
    public class StateDiagram 
    {
        private const int START_STATE = 1; 
        private XDocument xDocument => XDocument.Load(Source);

        public List<State> States { get; set; }
        public List<Edge> Edges { get; set; }

        public Dictionary<State, List<State>> AdjacencyList => GetAdjacencyList();
        public int StatesCount => States.Count;
        public int EdgesCount => Edges.Count;

        public string Source => @"C:\Github\Compiler\Compiler.Domain\Input\states-diagram.xml";

        public StateDiagram()
        {
            States = new List<State>();
            Edges = new List<Edge>();
            Initialize();
        }

        public void AddState(params State[] states)
        {
            foreach(var state in states)
            {
                if (state is null)
                    throw new ArgumentNullException(nameof(state));

                States.Add(state);
            }
        }

        public void AddEdge(State from, State to, List<StateType> weight)
        {
            if (from is null || to is null)
                throw new ArgumentNullException("Wrong from or to state");

            Edges.Add(new Edge(from, to, weight));
        }

        public void AddEdge(params Edge[] edges)
        {
            foreach (var edge in edges)
            {
                if (edge is null)
                    throw new ArgumentNullException(nameof(edge));

                Edges.Add(edge);
            }
        }

        public Dictionary<State, List<State>> GetAdjacencyList()
        {
            var adjacencyList = new Dictionary<State, List<State>>();

            foreach (var edge in Edges)
            {
                if (adjacencyList.TryGetValue(edge.From, out var states))
                    states.Add(edge.To);
                else
                    adjacencyList[edge.From] = new List<State>() { edge.To };
            }

            return adjacencyList;
        }

        public State GetState(int number) =>
            SearchService<State>.Instance.BinarySearch(number, 0, States.Count(), States);

        private Edge GetEdge(State from, State to) 
            => Edges.Where(edge => edge.From == from && edge.To == to).FirstOrDefault();
       
        private void Initialize()
        {
            var stateDiagram = xDocument.Element("diagram");

            foreach (XElement state in stateDiagram.Element("states").Elements("state"))
            {
                bool isFinish = bool.Parse(state.Attribute("isFinish").Value);

                int stateNumber = int.Parse(state.Element("number").Value);

                AddState(new State(stateNumber, isFinish));
            }

            foreach(XElement edge in stateDiagram.Element("edges").Elements("edge"))
            {
                var fromStateNumber = int.Parse(edge.Element("from").Value);

                var toStateNumber = int.Parse(edge.Element("to").Value);

                List<StateType> types = new List<StateType>(); // !!!!!!!!!!!!!

                foreach (var mark in edge.Element("classes").Elements("class"))
                {
                    types.Add((StateType)Enum.Parse(typeof(StateType), mark.Value.FirstLetterToUpper())); // !!!!!!!!!!!!!!!!!!
                }

                AddEdge(GetState(fromStateNumber), GetState(toStateNumber), types);
            }
        }

        public TextReaderResponse TraversalByRecursion(State state, string token,  TextReader textReader)
        {
            while (textReader.CurrentChar == 32 || textReader.CurrentChar == 13 || textReader.CurrentChar == 10)
                textReader.CurrentChar = textReader.reader.Read();
                
            if (textReader.HasRead)
                textReader.CurrentChar = textReader.reader.Read();
            else
                textReader.HasRead = true;

            if (textReader.CurrentChar == -1)
                return new TextReaderResponse(TextReaderStatus.EndOfFile);

            char currentChar = Convert.ToChar(textReader.CurrentChar);
             if (AdjacencyList.TryGetValue(state, out var children))
             {
                 foreach (var child in children)
                 {
                     var edge = GetEdge(state, child);

                     if(!edge.Rules.Any(rule => rule.Validate(currentChar) == true))
                         continue;

                     token += currentChar;
                     return TraversalByRecursion(child, token, textReader);
                 }

                 textReader.HasRead = false;
             }
             else
                 throw new Exception("Wrong token");

            return new TextReaderResponse(TextReaderStatus.Success, token);//new Token(token ?? throw new Exception("Wrong token"));
        }
    }
}
