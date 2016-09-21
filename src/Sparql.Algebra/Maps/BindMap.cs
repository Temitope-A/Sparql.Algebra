using Sparql.Algebra.Evaluators;
using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparql.Algebra.Maps
{
    public class BindMap : UnivariateMap
    {
        public Dictionary<string, object> BindingDictionary { get; }

        public BindMap(IMap map, Dictionary<string, object> bindingDictionary):base(map)
        {
            BindingDictionary = bindingDictionary;
        }

        public override IEnumerable<IMultiSetRow> EvaluateInternal<T>(IGraphSource source)
        {
            var set = InputMap.EvaluateInternal<T>(source);

            //return new signature
            yield return set.First();

            //bind result mappings
            foreach (IMultiSetRow row in set.Skip(1))
            {
                yield return MultiSetAlgebra.BindRow((ResultRow)row, BindingDictionary);
            }
        }
    }
}
