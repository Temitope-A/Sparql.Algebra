using System;
using System.Collections.Generic;
using Sparql.Algebra.GraphSources;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.GraphEvaluators
{
    /// <summary>
    /// Graph query models evaluator
    /// </summary>
    public interface IEvaluator
    {
        /// <summary>
        /// Evaluates a graph query model against a graph source
        /// </summary>
        /// <param name="queryModel">tree model of the query</param>
        /// <param name="offset">number of solutions to skip</param>
        /// <param name="limit">maximum number of solutions to take</param>
        /// <param name="source">query target</param>
        /// <returns>A collection of trees</returns>
        IEnumerable<LabelledTreeNode<object, Term>> Evaluate(LabelledTreeNode<object, Term> queryModel, int? offset, int? limit, IGraphSource source);
    }
}
