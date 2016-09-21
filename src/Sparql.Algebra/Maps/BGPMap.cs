using Sparql.Algebra.Evaluators;
using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System;
using System.Collections.Generic;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Represents a basic graph pattern map, to be evaluated against a graph database
    /// </summary>
    public class BGPMap : TerminalMap
    {
        public IEnumerable<object> StatementList { get; }

        public int? Limit { get; }

        public int? Offset { get; }       

        /// <summary>
        /// Constructor for a Basic Graph Pattern Map
        /// </summary>
        /// <param name="statementList">The graph pattern, serialized as a list of RDF statements, to evaluate</param>
        /// <param name="offset">Number of initial soluions to skip</param>
        /// <param name="limit">Maximum number of solutions to take</param>
        public BGPMap(IEnumerable<object> statementList, int? offset = null, int? limit = null)
        {
            StatementList = statementList;
            Offset = offset;
            Limit = limit;
        }

        /// <summary>
        /// Constructor for a Basic Graph Pattern Map
        /// </summary>
        /// <param name="statement">A single RDF statement to evaluate</param>
        /// <param name="offset">Number of initial soluions to skip</param>
        /// <param name="limit">Maximum number of solutions to take</param>
        public BGPMap(object Statement, int? offset = null, int? limit = null) : this(new[] { Statement}, offset, limit)
        {
        }

        /// <summary>
        /// Evaluate the Basic Graph Pattern. The evaluation is carried out by the delegate, which the client must define
        /// </summary>
        /// <param name="evaluator">A sparql algebra evaluator</param>
        /// <returns></returns>
        public override IEnumerable<IMultiSetRow> EvaluateInternal<T>(IGraphSource source)
        {
            var evaluator = Activator.CreateInstance(typeof(T), new[] { source }) as IEvaluator;

            foreach (var item in evaluator.Evaluate(StatementList, Offset, Limit))
            {
                yield return item;
            }
        }
    }
}
