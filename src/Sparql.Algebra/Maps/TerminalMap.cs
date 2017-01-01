namespace Sparql.Algebra.Maps
{
    /// <summary>
    /// Base class for terminal maps
    /// </summary>
    public abstract class TerminalMap : BaseMap
    {
        /// <summary>
        /// Trivial implementation
        /// </summary>
        /// <returns></returns>
        public override BaseMap Trim()
        {
            return this;
        }

        /// <summary>
        /// Trivial implementation
        /// </summary>
        /// <returns></returns>
        public override BaseMap Optimize()
        {
            return this;
        }
    }
}
