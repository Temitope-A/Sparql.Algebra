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
        public List<DirectedEdge<TE, TN>> Children { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public LabelledTreeNode(TN data)
        {
            Data = data;
            Children = new List<DirectedEdge<TE, TN>>();
        }

        /// <summary>
        /// Add new child given node data
        /// </summary>
        /// <returns></returns>
        public LabelledTreeNode<TN,TE> AddChild(TE edge, TN childData)
        {
            var child = new LabelledTreeNode<TN,TE>(childData);
            Children.Add(new DirectedEdge<TE, TN>(edge, child));

            return this;
        }

        /// <summary>
        /// Add new child given a node
        /// </summary>
        /// <returns></returns>
        public LabelledTreeNode<TN,TE> AddChild(TE edge, LabelledTreeNode<TN,TE> child)
        {
            Children.Add(new DirectedEdge<TE, TN>(edge, child));
            return this;
        }

        /// <summary>
        /// Returns children of the current node connected though the specified edge
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LabelledTreeNode<TN,TE>> Descend(TE edge)
        {
            return Children.Where(c => c.Edge.Equals(edge)).Select(child => child.TerminalNode);
        }

        /// <summary>
        /// Returns children of the current node of a given type
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LabelledTreeNode<TN,TE>> Descend<T>()
        {
            return Children.Where(c => c.TerminalNode.Data.GetType() == typeof(T)).Select(c=>c.TerminalNode);
        }

        /// <summary>
        /// Find the node at the given address. THe address must be unique
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

            return Children.Single(c=>c.Edge.Equals(currentPivot)).TerminalNode.Find(treeAddress.Skip(1).ToList());
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
                node.Children.Add(new DirectedEdge<TE, TN>(child.Edge, child.TerminalNode.Copy()));
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
                if (!stopCondition(child.TerminalNode))
                {
                    node.AddChild(child.Edge, child.TerminalNode.Traverse(nodeVisitor, stopCondition));
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
                result += string.Format(" {0}: {1};", child.Edge, child.TerminalNode.Data);
            }

            return Data.ToString() + " {" + result + "}";
        }
    }
}