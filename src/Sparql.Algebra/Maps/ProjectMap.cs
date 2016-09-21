using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System.Collections.Generic;
using System.Linq;

namespace Sparql.Algebra.Maps
{
    public class ProjectMap:UnivariateMap
    {
        public string[] ProjectedVariables { get; set; }

        public ProjectMap(IMap map, string[] projectedVariables):base(map)
        {
            ProjectedVariables = projectedVariables;
        }

        public override IEnumerable<IMultiSetRow> EvaluateInternal<T>(IGraphSource source)
        {
            var set = InputMap.EvaluateInternal<T>(source);

            //return new signature
            yield return new SignatureRow(ProjectedVariables);

            //project result mappings
            foreach (IMultiSetRow row in set.Skip(1))
            {
                yield return MultiSetAlgebra.ProjectRow((ResultRow)row, ProjectedVariables);
            }
        }
    }
}
