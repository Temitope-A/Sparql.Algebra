using System;

namespace Sparql.Algebra.GraphSources
{
    /// <summary>
    /// A graph source, to be used as target for graph queries
    /// </summary>
    public interface IGraphSource
    {
        /// <summary>
        /// Endpoint
        /// </summary>
        Uri EndPoint { get; }

        /// <summary>
        /// Named graph
        /// </summary>
        Uri RdfGraph { get; }
    }
}
