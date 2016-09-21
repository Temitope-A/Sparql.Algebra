using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System.Collections.Generic;

namespace Sparql.Algebra.Maps
{
    public class SliceMap : UnivariateMap
    {
        public int? Start { get; }

        public int? Size { get; }

        public SliceMap(IMap map, int? start, int? size):base(map)
        {
            Start = start;
            Size = size;
        }

        public override IEnumerable<IMultiSetRow> EvaluateInternal<T>(IGraphSource source)
        {
             var start = Start ?? 0;

            if (Size.HasValue)
            {
                foreach (var item in InputMap.EvaluateInternal<T>(source).SkipResults(start).TakeResults(Size.Value))
                {
                    yield return item;
                }
            }
            foreach (var item in InputMap.EvaluateInternal<T>(source).SkipResults(start))
            {
                yield return item;
            }
        }
    }
}