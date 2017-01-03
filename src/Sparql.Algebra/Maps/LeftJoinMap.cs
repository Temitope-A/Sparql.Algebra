using Sparql.Algebra.GraphSources;
using System;
using System.Collections.Generic;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Left join map
    /// </summary>
    public class LeftJoinMap : BivariateMap
    {
        private readonly Func<LabelledTreeNode<object, Term>, bool> _expression;

        private readonly List<JoinAddressPair> _addressPairList;

        /// <summary>
        /// Constructor for a left join map
        /// </summary>
        /// <param name="map1"></param>
        /// <param name="map2"></param>
        /// <param name="addressPairList"></param>
        /// <param name="expression"></param>
        public LeftJoinMap(IMap map1, IMap map2, List<JoinAddressPair> addressPairList, Func<LabelledTreeNode<object, Term>, bool> expression = null):base(map1, map2)
        {
            if (expression == null)
            {
                _expression = s => true;
            }
            else
            {
                _expression = expression;
            }

            _addressPairList = addressPairList;
        }

        /// <summary>
        /// Evaluates the left join map
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public override IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source)
        {
            var tempSet = new List<LabelledTreeNode<object, Term>>();

            foreach (var treeJoin in InputMap2.Evaluate<T>(source))
            {
                tempSet.Add(treeJoin);
            }

            foreach (var treeBase in InputMap1.Evaluate<T>(source))
            {
                var result = treeBase;

                foreach (var treeJoin in tempSet)
                {
                    if (JoinHelper.Compatible(treeBase, treeJoin, _addressPairList))
                    {
                        result = JoinHelper.Join(result, treeJoin, _addressPairList);
                    }
                }

                yield return result;
            }
        }
    }
}
