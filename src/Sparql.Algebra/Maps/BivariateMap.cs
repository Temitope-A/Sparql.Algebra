namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Base class for bivariate maps (maps which process and combine the results of two input maps)
    /// </summary>
    public abstract class BivariateMap : BaseMap
    {
        /// <summary>
        /// First input map
        /// </summary>
        public BaseMap InputMap1 { get; protected set; }

        /// <summary>
        /// Second input map
        /// </summary>
        public BaseMap InputMap2 { get; protected set; }

        /// <summary>
        /// Returns a new instance of a bivariate map
        /// </summary>
        /// <param name="map1">First input map</param>
        /// <param name="map2">Second input map</param>
        protected BivariateMap(IMap map1, IMap map2)
        {
            InputMap1 = (BaseMap)map1;
            InputMap2 = (BaseMap)map2;
        }

        /// <summary>
        /// Removes empty maps from this instance
        /// </summary>
        /// <returns></returns>
        public override BaseMap Trim()
        {
            if (InputMap1 is EmptyMap && InputMap2 is EmptyMap)
            {
                return new EmptyMap();
            }
            if (InputMap1 is EmptyMap)
            {
                return InputMap2.Trim();
            }
            if (InputMap2 is EmptyMap)
            {
                return InputMap1.Trim();
            }
            InputMap1 = InputMap1.Trim();
            InputMap2 = InputMap2.Trim();

            return this;
        }

        /// <summary>
        /// Optimizes the map execution
        /// </summary>
        /// <returns></returns>
        public override BaseMap Optimize()
        {
            InputMap1 = InputMap1.Optimize();
            InputMap2 = InputMap2.Optimize();

            return this;
        }
    }
}
