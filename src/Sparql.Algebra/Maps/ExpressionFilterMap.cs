using Sparql.Algebra.GraphSources;
using System;
using System.Collections.Generic;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Filter the result of subqueries by a boolean expression
    /// </summary>
    public class ExpressionFilterMap : UnivariateMap
    {
        private readonly Func<LabelledTreeNode<object, Term>, bool> _expression;

        /// <summary>
        /// Constructor for the expression filter map
        /// </summary>
        /// <param name="map"></param>
        /// <param name="expression"></param>
        public ExpressionFilterMap(IMap map, Func<LabelledTreeNode<object, Term>, bool> expression):base(map)
        {
            _expression = expression;
        }

        /// <summary>
        /// Evaluates the expression filter map
        /// </summary>
        public override IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source)
        {
            foreach (var tree in InputMap.Evaluate<T>(source))
            {
                if (_expression(tree))
                {
                    yield return tree;
                }
            }
        }
    }
}
