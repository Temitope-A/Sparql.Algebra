﻿using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Maps;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Test.Constants;
using Sparql.Algebra.Test.Mocks;
using Sparql.Algebra.Trees;
using Xunit;
using System.Linq;

namespace Sparql.Algebra.Test
{
    public class BgpMapTest
    {
        [Fact]
        public void AllResultsAreReturned()
        {
            var map = new BgpMap(new LabelledTreeNode<object, Term>(null));
            var results = map.Evaluate<MockEvaluator>(new GraphSource(TestUris.MathematiciansRepoUri));

            Assert.Equal(8, results.Count());
        }
    }
}
