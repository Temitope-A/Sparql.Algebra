namespace Sparql.Algebra.Maps
{
    public abstract class BivariateMap : BaseMap
    {
        public BaseMap InputMap1 { get; protected set; }

        public BaseMap InputMap2 { get; protected set; }

        public BivariateMap(IMap map1, IMap map2)
        {
            InputMap1 = (BaseMap)map1;
            InputMap2 = (BaseMap)map2;
        }

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

        public override BaseMap Optimize()
        {
            InputMap1 = InputMap1.Optimize();
            InputMap2 = InputMap2.Optimize();

            return this;
        }
    }
}
