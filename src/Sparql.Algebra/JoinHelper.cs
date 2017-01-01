using System;
using System.Collections.Generic;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra
{
    /// <summary>
    /// Represents a pair of tree addresses
    /// </summary>
    public class JoinAddressPair
    {
        /// <summary>
        /// Address for node in first tree
        /// </summary>
        public List<Term> TreeAddress1 { get; set; }
        /// <summary>
        /// Address for node in second tree
        /// </summary>
        public List<Term> TreeAddress2 { get; set; }
    }

    /// <summary>
    /// Join helper class
    /// </summary>
    public class JoinHelper
    {
        /// <summary>
        /// Check the compatibility of two trees
        /// </summary>
        /// <param name="tree1">first tree</param>
        /// <param name="tree2">second tree</param>
        /// <param name="addressPairList">sites to compare</param>
        /// <returns>true if the trees are compatible</returns>
        public static bool Compatible(LabelledTreeNode<object, Term> tree1, LabelledTreeNode<object, Term> tree2, List<JoinAddressPair> addressPairList)
        {
            foreach (var x in addressPairList)
            {
                if (!tree1.Find(x.TreeAddress1).Data.Equals(tree2.Find(x.TreeAddress2).Data))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Join two trees
        /// </summary>
        /// <param name="treeBase">base tree</param>
        /// <param name="treeJoin">tree to join</param>
        /// <param name="addressPairList">sites of join</param>
        /// <returns>a combined tree</returns>
        public static LabelledTreeNode<object, Term> Join(LabelledTreeNode<object, Term> treeBase, LabelledTreeNode<object, Term> treeJoin, List<JoinAddressPair> addressPairList)
        {
            var localTreeBase = treeBase.Copy();
            var localTreeJoin = treeJoin.Copy();

            foreach (var x in addressPairList)
            {
                foreach (var child in localTreeJoin.Find(x.TreeAddress2).Children)
                {
                    localTreeBase.Find(x.TreeAddress1).Children.Add(child.Key, child.Value);
                }
            }

            return localTreeBase;
        }
    }
}
