using System;

namespace Sparql.Algebra.Maps
{
    public abstract class TerminalMap : BaseMap
    {
        public override BaseMap Trim()
        {
            return this;
        }

        public override BaseMap Optimize()
        {
            return this;
        }
    }
}
