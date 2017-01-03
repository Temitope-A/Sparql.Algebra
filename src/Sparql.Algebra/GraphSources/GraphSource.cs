using System;

namespace Sparql.Algebra.GraphSources
{
    /// <summary>
    /// Base implementation of a graph source, to be used as target for graph queries
    /// </summary>
    public class GraphSource : IGraphSource
    {
        /// <summary>
        /// Endpoint
        /// </summary>
        public Uri EndPoint { get; }

        /// <summary>
        /// Initializes a new graph source
        /// </summary>
        public GraphSource(string endPoint)
        {
            EndPoint = new Uri(endPoint);
        }

        /// <summary>
        /// Initializes a new graph source
        /// </summary>
        public GraphSource(Uri endPoint)
        {
            EndPoint = endPoint;
        }
    }
}
