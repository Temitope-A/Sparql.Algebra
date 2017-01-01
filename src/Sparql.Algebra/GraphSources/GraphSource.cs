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
        /// Named graph
        /// </summary>
        public Uri RdfGraph { get; }

        /// <summary>
        /// Initializes a new graph source
        /// </summary>
        public GraphSource(string endPoint, string namedGraph = null)
        {
            EndPoint = new Uri(endPoint);
            RdfGraph = new Uri(namedGraph);
        }

        /// <summary>
        /// Initializes a new graph source
        /// </summary>
        public GraphSource(Uri endPoint, Uri namedGraph = null)
        {
            EndPoint = endPoint;
            RdfGraph = namedGraph;
        }
    }
}
