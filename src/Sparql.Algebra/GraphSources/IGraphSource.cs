using System;

namespace Sparql.Algebra.GraphSources
{
    public interface IGraphSource
    {
        Uri EndPoint { get; }
        Uri RdfGraph { get; }
    }
}
