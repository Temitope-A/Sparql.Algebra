using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System.Collections.Generic;

namespace Sparql.Algebra.Evaluators
{
    public interface IEvaluator
    {
        IGraphSource Source { get; }

        IEnumerable<IMultiSetRow> Evaluate(IEnumerable<object> StatementList, int? offset, int? limit);
    }
}
