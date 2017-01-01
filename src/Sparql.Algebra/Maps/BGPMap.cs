using Sparql.Algebra.GraphSources;
using System.Collections.Generic;
using Sparql.Algebra.GraphEvaluators;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Represents a basic graph pattern map, to be evaluated against a graph database
    /// </summary>
    public class BgpMap : TerminalMap
    {
        private IEvaluator _evaluator;

        private readonly LabelledTreeNode<object, Term> _queryModel;

        private readonly int? _limit;

        private readonly int? _offset;      

        /// <summary>
        /// Constructor for a Basic Graph Pattern Map
        /// </summary>
        /// <param name="queryModel">The graph pattern</param>
        /// <param name="offset">Number of initial soluions to skip</param>
        /// <param name="limit">Maximum number of solutions to take</param>
        public BgpMap(LabelledTreeNode<object, Term> queryModel, int? offset = null, int? limit = null)
        {
            _queryModel= queryModel;
            _offset = offset;
            _limit = limit;
        }

        /// <summary>
        /// Evaluate the Basic Graph Pattern. The evaluation is carried out by the delegate, which the client must define
        /// </summary>
        public override IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source)
        {
            if (_evaluator == null)
            {
                _evaluator = new T();
            }

            foreach (var item in _evaluator.Evaluate(_queryModel, _offset, _limit, source))
            {
                yield return item;
            }
        }
    }
}
