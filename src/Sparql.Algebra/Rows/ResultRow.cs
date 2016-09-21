using System.Collections.Generic;

namespace Sparql.Algebra.Rows
{
    public class ResultRow : IMultiSetRow
    {
        public Dictionary<string, object> SolutionMapping { get; set; }

        public ResultRow(Dictionary<string, object> data)
        {
            SolutionMapping = data;
        }
    }
}
