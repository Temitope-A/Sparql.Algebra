using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Maps;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Test.Constants;
using Sparql.Algebra.Test.Mocks;
using Sparql.Algebra.Trees;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace Sparql.Algebra.Test
{
    public class JoinMapTest
    {
        [Fact]
        public void JoinMathematiciansToNationality()
        {
            var map1 = new BgpMap(new LabelledTreeNode<object, Term>(null));
            var map2 = new BgpMap(new LabelledTreeNode<object, Term>(null));
            var nationMap = new ChangeSourceMap(map2, new GraphSource(TestUris.NationsRepouri));

            var joinSites = new List<JoinAddressPair> {
                new JoinAddressPair {
                    TreeAddress1 = new List<Term> { Biografy.Nationality },
                    TreeAddress2 = new List<Term> { }
                }
            };

            var map = new JoinMap(map1, nationMap, joinSites);

            var results = map.Evaluate<MockEvaluator>(new GraphSource(TestUris.MathematiciansRepoUri));

            Assert.Equal(8, results.Count());
        }
    }
}
