using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System.Collections.Generic;

namespace Sparql.Algebra.Maps
{
    public class EmptyMap:TerminalMap
    {
        public override IEnumerable<IMultiSetRow> EvaluateInternal<T>(IGraphSource source)
        {
            yield return new SignatureRow(new string[] {});
        }
    }
}
