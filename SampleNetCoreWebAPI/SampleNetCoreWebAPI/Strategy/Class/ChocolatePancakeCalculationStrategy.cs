using SampleNetCoreWebAPI.Model;
using SampleNetCoreWebAPI.Strategy.Interface;

namespace SampleNetCoreWebAPI.Strategy.Class
{
    public class ChocolatePancakeCalculationStrategy : ISweetCalculationStrategy
    {
        public Tuple<int, int> CalculateMaxSweets(Ingredient ingredient)
        {
            int purposeFlour = ingredient.PurposeFlour;
            int chocolate = ingredient.Chocolate;
            int oil = ingredient.Oil;
            int milk = ingredient.Milk;
            int sugar = ingredient.Sugar;
            int gulabJamun = Math.Min(Math.Min(purposeFlour, oil / 3), Math.Min(milk / 4, sugar / 3));

            int maxTotalSweets = 0;
            int maxGulabJamunCount = 0;
            int maxChocolatePancakeCount = 0;

            for (int i = 1; i <= gulabJamun; i++)
            {
                int pendingOil = oil - (i * 3);
                int pendingMilk = milk - (i * 4);
                int pendingSugar = sugar - (i * 3);
                int j = Math.Min(chocolate, Math.Min(pendingOil / 4, Math.Min(pendingMilk / 3, pendingSugar / 2)));

                if (i + j >= maxTotalSweets)
                {
                    maxTotalSweets = i + j;
                    maxGulabJamunCount = i;
                    maxChocolatePancakeCount = j;
                }
            }
            return new Tuple<int, int>(maxGulabJamunCount, maxChocolatePancakeCount);
        }
    }
}
