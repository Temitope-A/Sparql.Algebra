namespace Sparql.Algebra.Trees
{
    /// <summary>
    /// A directed edge in a labelled directed graph
    /// </summary>
    /// <typeparam name="TE"></typeparam>
    /// <typeparam name="TN"></typeparam>
    public class DirectedEdge<TE, TN>
    {
        /// <summary>
        /// Outgoing edge
        /// </summary>
        public TE Edge { get; set; }

        /// <summary>
        /// Node at the end of the edge
        /// </summary>
        public LabelledTreeNode<TN, TE> TerminalNode { get; set; }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="nodeData"></param>
        public DirectedEdge(TE edge, TN nodeData)
        {
            Edge = edge;
            TerminalNode = new LabelledTreeNode<TN, TE>(nodeData);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="node"></param>
        public DirectedEdge(TE edge, LabelledTreeNode<TN, TE> node)
        {
            Edge = edge;
            TerminalNode = node;
        }

        /// <summary>
        /// Returns a string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "- " + Edge + " -> " + TerminalNode;
        }
    }
}
