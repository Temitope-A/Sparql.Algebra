using System;
using Sparql.Algebra.GraphSources;
using System.Collections.Generic;
using Sparql.Algebra.GraphEvaluators;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// A sparql algebra object. Represents an algebrical map that can be evaluated on a graph source
    /// </summary>
    public interface IMap
    {     
        /// <summary>
        /// Evaluates the map and returns a graph object
        /// </summary>
        /// <typeparam name="T">Type of the evaluator</typeparam>
        /// <param name="source">Source the query is going to be evaluated against</param>
        /// <returns></returns>
        IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source) where T:IEvaluator, new();

        /// <summary>
        /// Simplyfies the map and eliminates redundancy where present
        /// </summary>
        /// <returns></returns>
        IMap Reduce();
    }
}