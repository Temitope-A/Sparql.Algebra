using System.Collections.Generic;
using Sparql.Algebra.Evaluators;
using Sparql.Algebra.Rows;
using Sparql.Algebra.GraphSources;

namespace Sparql.Algebra.Maps
{
    public abstract class BaseMap : IMap
    {
        public IEnumerable<IMultiSetRow> Evaluate<T>(IGraphSource source) where T : IEvaluator
        {
            return EvaluateInternal<T>(source);
        }

        public IMap Reduce()
        {
            return Trim().Optimize();
        }

        public abstract IEnumerable<IMultiSetRow> EvaluateInternal<T>(IGraphSource source) where T:IEvaluator;

        public abstract BaseMap Trim();

        public abstract BaseMap Optimize();
    }
}