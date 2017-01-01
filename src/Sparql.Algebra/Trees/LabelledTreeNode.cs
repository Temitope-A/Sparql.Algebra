using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparql.Algebra.Trees
{
    /// <summary>
    /// Tree structure
    /// </summary>
    public class LabelledTreeNode<TN,TE>
    {
        /// <summary>
        /// Data associated with the node
        /// </summary>
        public TN Data { get; set; }

        /// <summary>
        /// Children of current node
        /// </summary>
        public Dictionary<TE, LabelledTreeNode<TN,TE>> Children { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public LabelledTreeNode(TN data)
        {
            Data = data;
            Children = new Dictionary<TE, LabelledTreeNode<TN,TE>>();
        }

        /// <summary>
        /// Add new child given node data
        /// </summary>
        /// <returns></returns>
        public LabelledTreeNode<TN,TE> AddChild(TE edge, TN childData, bool returnChild = false)
        {
            var child = new LabelledTreeNode<TN,TE>(childData);
            Children.Add(edge, child);

            return returnChild ? child : this;
        }

        /// <summary>
        /// Add new child given a node
        /// </summary>
        /// <returns></returns>
        public LabelledTreeNode<TN,TE> AddChild(TE edge, LabelledTreeNode<TN,TE> child)
        {
            Children.Add(edge, child);
            return this;
        }

        /// <summary>
        /// Returns children of the current node connected though the specified edge
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LabelledTreeNode<TN,TE>> Descend(TE edge)
        {
            return Children.Where(c => c.Key.Equals(edge)).Select(child => child.Value);
        }

        /// <summary>
        /// Returns children of the current node of a given type
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LabelledTreeNode<TN,TE>> Descend<T>()
        {
            return Children.Where(c => c.Value.Data.GetType() == typeof(T)).Select(c=>c.Value);
        }

        /// <summary>
        /// Find the node at the given address
        /// </summary>
        /// <param name="treeAddress"></param>
        /// <returns>Returns null if the address is out of bounds</returns>
        public LabelledTreeNode<TN,TE> Find(List<TE> treeAddress)
        {
            if (!treeAddress.Any())
            {
                return this;
            }

            var currentPivot = treeAddress.First();

            var matchedChildren = this.Descend(currentPivot);

            if (!matchedChildren.Any())
            {
                return null;
            }

            if (matchedChildren.Count() >1)
            {
                throw new ArgumentException("Invalid tree for a join");
            }

            return Children[currentPivot].Find(treeAddress.Skip(1).ToList());
        }

        /// <summary>
        /// Copy the current tree node and descendents into new instance
        /// </summary>
        /// <returns></returns>
        public LabelledTreeNode<TN,TE> Copy()
        {
            var node = new LabelledTreeNode<TN,TE>(Data);

            foreach (var child in Children)
            {
                node.Children.Add(child.Key, child.Value.Copy());
            }

            return node;
        }

        /// <summary>
        /// Traverse the tree and perform operations recursively
        /// </summary>
        /// <returns>
        /// A new tree node that is, at every node, the result of the visit.
        /// The stopper decides whether the exploration of a branch should be passed
        /// </returns>
        public LabelledTreeNode<TY, TE> Traverse<TY>(TreeNodeVisitor<TN, TY> nodeVisitor, Func<LabelledTreeNode<TN, TE>, bool> stopCondition = null)
        {
            var node = new LabelledTreeNode<TY, TE>(nodeVisitor(Data));
            if (stopCondition == null)
            {
                stopCondition = d => false;
            }
            foreach (var child in Children)
            {
                if (!stopCondition(child.Value))
                {
                    node.AddChild(child.Key, child.Value.Traverse(nodeVisitor, stopCondition));
                }
            }

            return node;
        }

        /// <summary>
        /// String representation of a labelled directed tree
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";

            foreach (var child in Children)
            {
                result += string.Format(" {0}: {1};", child.Key, child.Value.Data);
            }

            return Data.ToString() + " {" + result + "}";
        }
    }
}