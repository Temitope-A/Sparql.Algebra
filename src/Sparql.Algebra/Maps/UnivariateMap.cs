using System;

namespace Sparql.Algebra.Maps
{
    public abstract class UnivariateMap : BaseMap
    {
        public BaseMap InputMap { get; protected set; }

        public UnivariateMap(IMap map)
        {
            InputMap = (BaseMap)map;
        }

        public override BaseMap Trim()
        {
            if (InputMap is EmptyMap)
            {
                return new EmptyMap();
            }

            InputMap = InputMap.Trim();

            return this;
        }

        public override BaseMap Optimize()
        {
            InputMap = InputMap.Optimize();
            return this;
        }
    }
}
