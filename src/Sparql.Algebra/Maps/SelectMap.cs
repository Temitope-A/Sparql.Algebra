using Sparql.Algebra.GraphSources;
using System.Collections.Generic;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Join two query results
    /// </summary>
    public class SelectMap : BivariateMap
    {
        private readonly List<JoinAddressPair> _addressPairList;

        /// <summary>
        /// Constructor for the join map
        /// </summary>
        /// <param name="map1"></param>
        /// <param name="map2"></param>
        /// <param name="addressPairList"></param>
        public SelectMap(IMap map1, IMap map2, List<JoinAddressPair> addressPairList):base(map1, map2)
        {
            _addressPairList = addressPairList;
        }

        /// <summary>
        /// Evaluates the join map
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
                foreach (var treeJoin in tempSet)
                {
                    if (JoinHelper.Compatible(treeBase, treeJoin, _addressPairList))
                    {
                        yield return treeJoin;
                    }
                }
            }
        }
    }
}
