using System;
using Sparql.Algebra.GraphSources;
using System.Collections.Generic;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Represents an empty map
    /// </summary>
    public class EmptyMap:TerminalMap
    {
        /// <summary>
        /// Evaluates the empty map
        /// </summary>
        /// <returns>EMpty tree node</returns>
        public override IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source)
        {
            yield return new LabelledTreeNode<object, Term>(null);
        }
    }
}
