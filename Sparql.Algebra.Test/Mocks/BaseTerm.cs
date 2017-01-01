using Sparql.Algebra.RDF;

namespace Sparql.Algebra.Test.Mocks
{
    public class BaseTerm:Term
    {
        public string Id { get; }

        public BaseTerm(string id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
