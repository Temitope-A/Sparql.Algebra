using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System.Collections.Generic;
using System.Linq;

namespace Sparql.Algebra.Maps
{
    public class JoinMap:BivariateMap
    {
        public JoinMap(IMap map1, IMap map2):base(map1, map2)
        {
        }

        public override IEnumerable<IMultiSetRow> EvaluateInternal<T>(IGraphSource source)
        {
            var set1 = InputMap1.EvaluateInternal<T>(source);
            var set2 = InputMap2.EvaluateInternal<T>(source);

            //Using this temp set is important to avoid posting a new query every time the sequence is rewinded
            List<IMultiSetRow> tempSet = null;

            //get common variables
            var signature1 = (SignatureRow)set1.First();
            var signature2 = (SignatureRow)set2.First();
            var commonVariables = MultiSetAlgebra.GetCommonVariables(signature1, signature2);

            //return new signature
            yield return MultiSetAlgebra.JoinSignatures(signature1, signature2, commonVariables);

            //return result mappings
            foreach (var row1 in set1.Skip(1))
            {
                if (tempSet == null)
                {
                    tempSet = new List<IMultiSetRow>();

                    foreach (var row2 in set2.Skip(1))
                    {
                        tempSet.Add(row2);

                        if (MultiSetAlgebra.Compatible((ResultRow)row1, (ResultRow)row2, commonVariables))
                        {
                            yield return MultiSetAlgebra.JoinRows((ResultRow)row1, (ResultRow)row2, commonVariables);
                        }
                    }
                }

                else
                {
                    foreach (var row2 in tempSet)
                    {
                        if (MultiSetAlgebra.Compatible((ResultRow)row1, (ResultRow)row2, commonVariables))
                        {
                            yield return MultiSetAlgebra.JoinRows((ResultRow)row1, (ResultRow)row2, commonVariables);
                        }
                    }
                }
                
            }
        }

        public override BaseMap Optimize()
        {
            InputMap1 = InputMap1.Optimize();
            InputMap2 = InputMap2.Optimize();

            var map1 = InputMap1 as BGPMap;
            var map2 = InputMap2 as BGPMap;

            if (map1 != null && map1.Limit == null && map1.Offset == null)
            {
                if (map2 != null && map2.Limit == null && map2.Offset == null)
                {
                    return new BGPMap(map1.StatementList.Concat(map2.StatementList));
                }
            }

            return this;
        }
    }
}
