using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparql.Algebra.Maps
{
    public class ExpressionFilterMap : UnivariateMap
    {
        public Func<ResultRow, bool> Expression { get; }

        public ExpressionFilterMap(IMap map, Func<ResultRow, bool> expression):base(map)
        {
            Expression = expression;
        }

        public override IEnumerable<IMultiSetRow> EvaluateInternal<T>(IGraphSource source)
        {
            var set = InputMap.EvaluateInternal<T>(source);

            //yield signature
            yield return (SignatureRow)set.First();

            //filter
            foreach (var row in set.Skip(1))
            {
                if (Expression((ResultRow)row))
                {
                    yield return row;
                }
            }
        }
    }
}
