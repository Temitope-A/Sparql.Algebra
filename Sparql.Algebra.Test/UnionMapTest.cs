using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Maps;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Test.Constants;
using Sparql.Algebra.Test.Mocks;
using Sparql.Algebra.Trees;
using System.Linq;
using Xunit;

namespace Sparql.Algebra.Test
{
    public class UnionMapTest
    {
        [Fact]
        public void AllResultsAreReturned()
        {
            var map1 = new BgpMap(new LabelledTreeNode<object, Term>(null));
            var map2 = new BgpMap(new LabelledTreeNode<object, Term>(null));

            var map = new UnionMap(map1, map2);

            var results = map.Evaluate<MockEvaluator>(new GraphSource(TestUris.MathematiciansRepoUri));

            Assert.Equal(16, results.Count());
        }
    }
}
