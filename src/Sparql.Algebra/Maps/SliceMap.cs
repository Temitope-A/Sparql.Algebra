using System;
using Sparql.Algebra.GraphSources;
using System.Collections.Generic;
using Sparql.Algebra.RDF;
using Sparql.Algebra.Trees;

namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Get a subset of the submap results
    /// </summary>
    public class SliceMap : UnivariateMap
    {
        private readonly int? _start;

        private readonly int? _size;

        /// <summary>
        /// Constructor for the lice map
        /// </summary>
        /// <param name="map"></param>
        /// <param name="start"></param>
        /// <param name="size"></param>
        public SliceMap(IMap map, int? start, int? size):base(map)
        {
            _start = start;
            _size = size;
        }

        /// <summary>
        /// Evaluates the slice map
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public override IEnumerable<LabelledTreeNode<object, Term>> Evaluate<T>(IGraphSource source)
        {
            var start = _start ?? 0;

            var count = 0;

            foreach (var item in InputMap.Evaluate<T>(source))
            {
                if (count < start)
                {
                    //skip
                }
                else if (_size.HasValue && count - start >= _size.Value)
                {
                    //skip
                }
                else
                {
                    yield return item;
                }
                count++;
            }            
        }
    }
}