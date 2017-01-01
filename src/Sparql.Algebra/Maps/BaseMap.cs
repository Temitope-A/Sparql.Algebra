using System;
using System.Collections.Generic;
using Sparql.Algebra.GraphEvaluators;
using Sparql.Algebra.GraphSources;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Base class for sparql maps. Factors reduction into a two stage operation: trim of empty maps and optimization
    /// </summary>
    public abstract class BaseMap : IMap
    {
        /// <summary>
        /// Evaluates the map and returns a graph object
        /// </summary>
        public abstract IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source) where T : IEvaluator, new();

        /// <summary>
        /// Simplyfies the map and eliminates redundancy where present
        /// </summary>
        public IMap Reduce()
        {
            return Trim().Optimize();
        }

        /// <summary>
        /// Removes empty maps from this instance
        /// </summary>
        /// <returns></returns>
        public abstract BaseMap Trim();

        /// <summary>
        /// Optimizes the map execution
        /// </summary>
        /// <returns></returns>
        public abstract BaseMap Optimize();
    }
}