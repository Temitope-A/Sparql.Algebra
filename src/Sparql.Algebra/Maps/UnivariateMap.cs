namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Base class for univariate maps (maps which process the results of another map)
    /// </summary>
    public abstract class UnivariateMap : BaseMap
    {
        /// <summary>
        /// Input map
        /// </summary>
        public BaseMap InputMap { get; protected set; }

        /// <summary>
        /// Returns a new instance of a univariate map
        /// </summary>
        /// <param name="map">Input map</param>
        protected UnivariateMap(IMap map)
        {
            InputMap = (BaseMap)map;
        }

        /// <summary>
        /// Removes empty maps from this instance
        /// </summary>
        /// <returns></returns>
        public override BaseMap Trim()
        {
            if (InputMap is EmptyMap)
            {
                return new EmptyMap();
            }

            InputMap = InputMap.Trim();

            return this;
        }

        /// <summary>
        /// Optimizes the map execution
        /// </summary>
        /// <returns></returns>
        public override BaseMap Optimize()
        {
            InputMap = InputMap.Optimize();
            return this;
        }
    }
}
