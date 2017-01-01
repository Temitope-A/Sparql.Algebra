using System;
using System.Collections.Generic;
using Sparql.Algebra.GraphSources;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.GraphEvaluators
{
    /// <summary>
    /// Abstract implementation of a IEvaluator for graph query models
    /// </summary>
    public abstract class BaseEvaluator:IEvaluator
    {
        /// <summary>
        /// Evaluates a graph query model against a graph source
        /// </summary>
        /// <param name="queryModel">tree model of the query</param>
        /// <param name="offset">number of solutions to skip</param>
        /// <param name="limit">maximum number of solutions to take</param>
        /// <param name="source">query target</param>
        /// <returns>A collection of trees</returns>
        public IEnumerable<LabelledTreeNode<object, Term>> Evaluate(LabelledTreeNode<object, Term> queryModel, int? offset, int? limit, IGraphSource source)
        {
            var query = StringifyQueryModel(queryModel);

            return ExecuteQuery(query, source);
        }

        /// <summary>
        /// Converts the graph query model to a query string
        /// </summary>
        /// <param name="queryModel">tree model of the query</param>
        /// <returns></returns>
        protected abstract string StringifyQueryModel(LabelledTreeNode<object, Term> queryModel);

        /// <summary>
        /// Execute the graph query model against the graph source
        /// </summary>
        /// <param name="query">query string</param>
        /// <param name="source">query target</param>
        /// <returns></returns>
        protected abstract IEnumerable<LabelledTreeNode<object, Term>> ExecuteQuery(string query, IGraphSource source);
    }
}
