using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparql.Algebra.Maps
{
    public class LeftJoinMap : BivariateMap
    {
        public Func<ResultRow, bool> Expression { get; }

        public LeftJoinMap(IMap map1, IMap map2, Func<ResultRow, bool> expression = null):base(map1, map2)
        {
            if (expression == null)
            {
                Expression = s => true;
            }
            else
            {
                Expression = expression;
            }
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
                bool flag = true;

                if (tempSet == null)
                {
                    tempSet = new List<IMultiSetRow>();

                    foreach (var row2 in set2.Skip(1))
                    {
                        tempSet.Add(row2);

                        if (MultiSetAlgebra.Compatible((ResultRow)row1, (ResultRow)row2, commonVariables) && Expression(MultiSetAlgebra.JoinRows((ResultRow)row1, (ResultRow)row2, commonVariables)))
                        {
                            flag = false;
                            yield return MultiSetAlgebra.JoinRows((ResultRow)row1, (ResultRow)row2, commonVariables);
                        }
                    }
                }

                else
                {
                    foreach (var row2 in tempSet)
                    {
                        if (MultiSetAlgebra.Compatible((ResultRow)row1, (ResultRow)row2, commonVariables) && Expression(MultiSetAlgebra.JoinRows((ResultRow)row1, (ResultRow)row2, commonVariables)))
                        {
                            flag = false;
                            yield return MultiSetAlgebra.JoinRows((ResultRow)row1, (ResultRow)row2, commonVariables);
                        }
                    }
                }

                if (flag)
                {
                    var signatureExtension = signature2.VariableList.Where(x => !commonVariables.Contains(x)).ToArray();
                    yield return MultiSetAlgebra.ExtendRow((ResultRow)row1, signatureExtension);
                }
            }
        }
    }
}
