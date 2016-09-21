using Xunit;
using System.Collections.Generic;
using System.Linq;
using Sparql.Algebra.Rows;
using Sparql.Algebra.Maps;

namespace Sparql.Algebra.Test
{
    public class LeftJoinMapTest
    {
        //[Fact]
        //public void HappyPath()
        //{
        //    var signature1 = new SignatureRow(new[] { "a", "b" });
        //    var signature2 = new SignatureRow(new[] { "b", "c" });

        //    var result11 = new ResultRow(new Dictionary<string, object> { { "b", true }, { "a", "A" } });
        //    var result12 = new ResultRow(new Dictionary<string, object> { { "b", false }, { "a", "A" } });

        //    var result21 = new ResultRow(new Dictionary<string, object> { { "b", true }, { "c", 99 } });
        //    var result22 = new ResultRow(new Dictionary<string, object> { { "b", true }, { "c", 100 } });

        //    var evaluator = new MockEvaluator();
        //    evaluator.AddResultBlock(new List<IMultiSetRow> { signature1, result11, result12 });
        //    evaluator.AddResultBlock(new List<IMultiSetRow> { signature2, result21, result22 });

        //    var map1 = new BGPMap(null, null, null);
        //    var map2 = new BGPMap(null, null, null);

        //    var joinMap = new LeftJoinMap(map1, map2);

        //    var results = joinMap.Evaluate(evaluator);

        //    Assert.Equal(4, results.Count());
        //}

        //[Fact]
        //public void LeftJoinToEmptySet()
        //{
        //    var signature1 = new SignatureRow(new[] { "a", "b" });
        //    var result11 = new ResultRow(new Dictionary<string, object> { { "b", 1 }, { "a", "A" } });
        //    var evaluator = new MockEvaluator();
        //    evaluator.AddResultBlock(new List<IMultiSetRow> { signature1, result11 });

        //    var map1 = new BGPMap(null, null, null);
        //    var map2 = new EmptyMap();

        //    var leftJoinMap = new LeftJoinMap(map1, map2);

        //    var results = leftJoinMap.Evaluate(evaluator);

        //    Assert.Equal(2, results.Count());
        //}

        //[Fact]
        //public void EmptySetLeftJoin()
        //{
        //    var signature1 = new SignatureRow(new[] { "a", "b" });
        //    var result11 = new ResultRow(new Dictionary<string, object> { { "b", 1 }, { "a", "A" } });
        //    var evaluator = new MockEvaluator();
        //    evaluator.AddResultBlock(new List<IMultiSetRow> { signature1, result11 });

        //    var map1 = new BGPMap(null, null, null);
        //    var map2 = new EmptyMap();

        //    var leftJoinMap = new LeftJoinMap(map2, map1);

        //    var results = leftJoinMap.Evaluate(evaluator);

        //    Assert.Equal(2, results.Count());
        //}
    }
}
