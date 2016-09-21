using Sparql.Algebra.Evaluators;
using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System.Collections.Generic;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// A sparql algebra object. Represents an algebrical map that can be evaluated on a dataset and returns a multiset
    /// </summary>
    public interface IMap
    {     
        /// <summary>
        /// Evaluates the map
        /// </summary>
        /// <param name="evaluator"></param>
        /// <returns></returns>
        IEnumerable<IMultiSetRow> Evaluate<T>(IGraphSource source) where T:IEvaluator;

        IMap Reduce();
    }
}