using System;
using Sparql.Algebra.GraphSources;
using System.Collections.Generic;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Bind variables to constants specified in the query
    /// </summary>
    public class BindMap : UnivariateMap
    {
        private readonly Dictionary<List<Term>, object> _bindingDictionary;

        /// <summary>
        /// Constructor for the Bind map
        /// </summary>
        /// <param name="map"></param>
        /// <param name="bindingDictionary"></param>
        public BindMap(IMap map, Dictionary<List<Term>, object> bindingDictionary):base(map)
        {
            _bindingDictionary = bindingDictionary;
        }

        /// <summary>
        /// Evaluates the Bind Map.
        /// </summary>
        /// <param name="source">query target</param>
        public override IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source)
        {
            foreach (var tree in InputMap.Evaluate<T>(source))
            {
                foreach (var binding in _bindingDictionary)
                {
                    if (tree.Find(binding.Key) != null)
                    {
                        tree.Find(binding.Key).Value = binding.Value;
                    }
                }

                yield return tree;
            }
        }
    }
}
