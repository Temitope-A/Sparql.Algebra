using System;
using Sparql.Algebra.GraphSources;
using System.Collections.Generic;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Represents a change source map.
    /// </summary>
    public class ChangeSourceMap : UnivariateMap
    {
        private readonly IGraphSource _source;

        /// <summary>
        /// Change the query target for all subqueries
        /// </summary>
        /// <param name="map"></param>
        /// <param name="source"></param>
        public ChangeSourceMap(IMap map, IGraphSource source) : base(map)
        {
            _source = source;
        }

        /// <summary>
        /// Evaluates the Change source map
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">query target</param>
        /// <returns></returns>
        public override IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source)
        {
            foreach (var item in InputMap.Evaluate<T>(_source))
            {
                yield return item;
            }
        }
    }
}
