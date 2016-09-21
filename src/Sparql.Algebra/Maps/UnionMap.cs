using Sparql.Algebra.Rows;
using System.Collections.Generic;
using System;
using System.Linq;
using Sparql.Algebra.GraphSources;

namespace Sparql.Algebra.Maps
{
    public class UnionMap:BivariateMap
    {
        public UnionMap(IMap map1, IMap map2):base(map1, map2)
        {
        }

        public override IEnumerable<IMultiSetRow> EvaluateInternal<T>(IGraphSource source)
        {
            var set1 = InputMap1.EvaluateInternal<T>(source);
            var set2 = InputMap2.EvaluateInternal<T>(source);

            //get join matrix
            var signature1 = (SignatureRow)set1.First();
            var signature2 = (SignatureRow)set2.First();
            var commonVariables = MultiSetAlgebra.GetCommonVariables(signature1, signature2);

            //check there is full compatibility of variables

            if (commonVariables.Length != signature1.VariableList.Length)
            {
                throw new ArgumentException("Invalid union");
            }

            //return first signature
            yield return signature1;

            foreach (var row in set1.Skip(1))
            {
                yield return row;
            }

            foreach (var row in set2.Skip(1))
            {
                yield return row;
            }
        }
    }
}
