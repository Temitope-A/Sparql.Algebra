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
    public class ChangeSourceMapTest
    {
        [Fact]
        public void AllResultsAreReturned()
        {
            var map1 = new BgpMap(new LabelledTreeNode<object, Term>(null));
            var map = new ChangeSourceMap(map1, new GraphSource(TestUris.PhysicistRepoUri));

            var results = map.Evaluate<MockEvaluator>(new GraphSource(TestUris.MathematiciansRepoUri));

            Assert.Equal(7, results.Count());
        }
    }
}
