using System;
using System.Collections.Generic;
using Sparql.Algebra.GraphSources;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Set union of the sub maps
    /// </summary>
    public class UnionMap:BivariateMap
    {
        /// <summary>
        /// Constructor for the union map
        /// </summary>
        /// <param name="map1"></param>
        /// <param name="map2"></param>
        public UnionMap(IMap map1, IMap map2):base(map1, map2)
        {
        }

        /// <summary>
        /// Evaluates the union map
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public override IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source)
        {       
            foreach (var tree in InputMap1.Evaluate<T>(source))
            {
                yield return tree;
            }

            foreach (var tree in InputMap2.Evaluate<T>(source))
            {
                yield return tree;
            }
        }
    }
}
