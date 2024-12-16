using SampleNetCoreWebAPI.Model;

namespace SampleNetCoreWebAPI.Strategy.Interface
{
    public interface ISweetCalculationStrategy
    {
        public Tuple<int, int> CalculateMaxSweets(Ingredient ingredient);
    }
}
