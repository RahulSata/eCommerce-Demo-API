using SampleNetCoreWebAPI.Model;

namespace SampleNetCoreWebAPI.Business.Interface
{
    public interface ISweetMakerBL
    {
        SweetCount CalculateMaxSweets(Ingredient ingredient);
    }
}
