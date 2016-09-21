using Xunit;
using System.Collections.Generic;
using System.Linq;
using Sparql.Algebra.Rows;
using Sparql.Algebra.Maps;

namespace Sparql.Algebra.Test
{
    public class JoinMapTest
    {
        //[Fact]
        //public void HappyPath()
        //{
        //    var signature1 = new SignatureRow(new[] { "a", "b" });
        //    var signature2 = new SignatureRow(new[] { "b", "c" });

        //    var result11 = new ResultRow(new Dictionary<string, object> { {"b" , 1 }, { "a", "A" } });

        //    var result21 = new ResultRow(new Dictionary<string, object> { { "b", 1 }, { "c", 99 } });
        //    var result22 = new ResultRow(new Dictionary<string, object> { { "b", 1 }, { "c", 100 } });

        //    var evaluator = new MockEvaluator();
        //    evaluator.AddResultBlock(new List<IMultiSetRow> { signature1, result11 });
        //    evaluator.AddResultBlock(new List<IMultiSetRow> { signature2, result21, result22 });

        //    var map1 = new BGPMap(null, null, null);
        //    var map2 = new BGPMap(null, null, null);

        //    var joinMap = new JoinMap(map1, map2);

        //    var results = joinMap.Evaluate<MockEvaluator>(evaluator);

        //    Assert.Equal(3, results.Count());
        //}

        //[Fact]
        //public void JoinToEmptySet()
        //{
        //    var signature1 = new SignatureRow(new[] { "a", "b" });
        //    var result11 = new ResultRow(new Dictionary<string, object> { { "b", 1 }, { "a", "A" } });
        //    var evaluator = new MockEvaluator();
        //    evaluator.AddResultBlock(new List<IMultiSetRow> { signature1, result11 });

        //    var map1 = new BGPMap(null, null, null);
        //    var map2 = new EmptyMap();

        //    var joinMap = new JoinMap(map1, map2);

        //    var results = joinMap.Evaluate(evaluator);

        //    Assert.Equal(2, results.Count());
        //}
    }
}
