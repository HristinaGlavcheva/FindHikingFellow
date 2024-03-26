using FindHikingFellow.Core.Models.Feature;

namespace FindHikingFellow.Core.Contracts
{
    public interface IFeatureService
    {
        Task<List<ListFeaturesViewModel>> ListFeaturesAsync();
    }
}
