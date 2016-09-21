using Sparql.Algebra.Evaluators;
using Sparql.Algebra.GraphSources;
using Sparql.Algebra.Rows;
using System;
using System.Collections.Generic;

namespace Sparql.Algebra.Test
{
    public class MockEvaluator:IEvaluator
    {
        private List<IEnumerable<IMultiSetRow>> _resultBlocks;
        private int count = 0;

        public IGraphSource Source
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public MockEvaluator()
        {
            _resultBlocks = new List<IEnumerable<IMultiSetRow>>();
        }

        public void AddResultBlock(IEnumerable<IMultiSetRow> block)
        {
            _resultBlocks.Add(block);
        }

        public IEnumerable<IMultiSetRow> Evaluate(IEnumerable<object> StatementList, int? offset = 0, int? limit = null)
        {
            return _resultBlocks[count++];
        }

        public void SetSource(IGraphSource source)
        {
            throw new NotImplementedException();
        }
    }
}
