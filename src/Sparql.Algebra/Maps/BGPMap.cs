using Sparql.Algebra.GraphSources;
using System.Collections.Generic;
using Sparql.Algebra.GraphEvaluators;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;
using Sparql.Algebra.Filters;

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

        private readonly IFilter _filter;

        /// <summary>
        /// Constructor for a Basic Graph Pattern Map
        /// </summary>
        /// <param name="queryModel">the graph pattern</param>
        /// <param name="offset">number of initial soluions to skip</param>
        /// <param name="limit">maximum number of solutions to take</param>
        /// <param name="filter">a bgp map filter</param>
        public BgpMap(LabelledTreeNode<object, Term> queryModel, int? offset = null, int? limit = null, IFilter filter = null)
        {
            _queryModel= queryModel;
            _offset = offset;
            _limit = limit;
            _filter = filter;
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

            foreach (var item in _evaluator.Evaluate(_queryModel, _offset, _limit, _filter, source))
            {
                yield return item;
            }
        }
    }
}
