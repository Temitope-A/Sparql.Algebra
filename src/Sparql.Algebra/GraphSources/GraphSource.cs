using System;

namespace Sparql.Algebra.GraphSources
{
    public class GraphSource : IGraphSource
    {
        public Uri EndPoint { get; }

        public Uri RdfGraph { get; }

        public GraphSource(string uri)
        {
            EndPoint = new Uri(uri);
        }
    }
}
