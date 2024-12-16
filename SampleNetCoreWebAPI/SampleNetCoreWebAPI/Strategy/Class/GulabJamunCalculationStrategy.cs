using SampleNetCoreWebAPI.Model;
using SampleNetCoreWebAPI.Strategy.Interface;

namespace SampleNetCoreWebAPI.Strategy.Class
{
    public class GulabJamunCalculationStrategy : ISweetCalculationStrategy
    {
        public Tuple<int, int> CalculateMaxSweets(Ingredient ingredient)
        {
            int purposeFlour = ingredient.PurposeFlour;
            int chocolate = ingredient.Chocolate;
            int oil = ingredient.Oil;
            int milk = ingredient.Milk;
            int sugar = ingredient.Sugar;

            int chocolatePancake = Math.Min(Math.Min(chocolate, oil / 4), Math.Min(milk / 3, sugar / 2));

            int maxTotalSweets = 0;
            int maxGulabJamunCount = 0;
            int maxChocolatePancakeCount = 0;

            for (int i = 1; i <= chocolatePancake; i++)
            {
                int pendingOil = oil - (i * 4);
                int pendingMilk = milk - (i * 3);
                int pendingSugar = sugar - (i * 2);
                int j = Math.Min(purposeFlour, Math.Min(pendingOil / 3, Math.Min(pendingMilk / 4, pendingSugar / 3)));

                if (i + j >= maxTotalSweets)
                {
                    maxTotalSweets = i + j;
                    maxGulabJamunCount = j;
                    maxChocolatePancakeCount = i;
                }
            }

            return new Tuple<int, int>(maxGulabJamunCount, maxChocolatePancakeCount);
        }
    }
}
