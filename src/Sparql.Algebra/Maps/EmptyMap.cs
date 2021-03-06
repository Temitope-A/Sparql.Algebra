﻿using Sparql.Algebra.GraphSources;
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
        public override IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source)
        {
            yield break;
        }
    }
}
