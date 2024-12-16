using SampleNetCoreWebAPI.Business.Interface;
using SampleNetCoreWebAPI.Model;
using SampleNetCoreWebAPI.Strategy.Class;
using SampleNetCoreWebAPI.Strategy.Interface;

namespace SampleNetCoreWebAPI.Business.Class
{
    public class SweetMakerBL : ISweetMakerBL
    {

        private readonly ISweetCalculationStrategy gulabJamunStrategy;
        private readonly ISweetCalculationStrategy chocolatePancakeStrategy;

        public SweetMakerBL()
        {
            this.gulabJamunStrategy = new GulabJamunCalculationStrategy();
            this.chocolatePancakeStrategy = new ChocolatePancakeCalculationStrategy();
        }

        public SweetCount CalculateMaxSweets(Ingredient ingredient)
        {
            Tuple<int, int> gulabJamunStrategyCount = gulabJamunStrategy.CalculateMaxSweets(ingredient);
            Tuple<int, int> chocolateStrategyCount = chocolatePancakeStrategy.CalculateMaxSweets(ingredient);

            if (gulabJamunStrategyCount.Item1 + gulabJamunStrategyCount.Item2
                > chocolateStrategyCount.Item1 + chocolateStrategyCount.Item2)
            {
                return new SweetCount()
                {
                    GulabJamunCount = gulabJamunStrategyCount.Item1,
                    ChocolatePanCakeCount = gulabJamunStrategyCount.Item2
                };
            }
            else
            {
                return new SweetCount()
                {
                    GulabJamunCount = chocolateStrategyCount.Item1,
                    ChocolatePanCakeCount = chocolateStrategyCount.Item2
                };
            }
        }
    }
}
