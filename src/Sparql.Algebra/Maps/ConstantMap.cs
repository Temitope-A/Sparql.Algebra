using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;
using System.Collections.Generic;
using Sparql.Algebra.GraphSources;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Represent a constant map
    /// </summary>
    public class ConstantMap:TerminalMap
    {
        private IEnumerable<LabelledTreeNode<object, Term>> _value;

        /// <summary>
        /// Returns an instance of a constant map which will return its value whenever executed
        /// </summary>
        /// <param name="value"></param>
        public ConstantMap(LabelledTreeNode<object, Term> value)
        {
            _value = new[] { value };
        }

        /// <summary>
        /// Returns an instance of a constant map which will return its value whenever executed
        /// </summary>
        /// <param name="value"></param>
        public ConstantMap(IEnumerable<LabelledTreeNode<object, Term>> value)
        {
            _value = value;
        }

        /// <summary>
        /// Evaluates the constant map
        /// </summary>
        public override IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source)
        {
            foreach (var item in _value)
            {
                yield return new LabelledTreeNode<object, Term>(item);
            }
        }
    }
}
