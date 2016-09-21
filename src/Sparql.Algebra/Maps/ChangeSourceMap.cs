using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System.Collections.Generic;

namespace Sparql.Algebra.Maps
{
    public class ChangeSourceMap : UnivariateMap
    {
        public IGraphSource Source { get; }

        public ChangeSourceMap(IMap map, IGraphSource source) : base(map)
        {
            Source = source;
        }

        public override IEnumerable<IMultiSetRow> EvaluateInternal<T>(IGraphSource source)
        {
            foreach (var item in InputMap.EvaluateInternal<T>(Source))
            {
                yield return item;
            }
        }
    }
}
