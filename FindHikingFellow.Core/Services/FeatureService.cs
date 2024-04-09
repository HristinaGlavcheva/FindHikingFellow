using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Feature;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FindHikingFellow.Core.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IRepository featureRepository;

        public FeatureService(IRepository _featureRepository)
        {
            featureRepository = _featureRepository;
        }

        public async Task<List<FeatureViewModel>> ListFeaturesAsync()
        {
            var features = featureRepository
                .AllAsNoTracking<Feature>()
                .Select(f => new FeatureViewModel
                {
                    IsChecked = true,
                    Description = f.Name,
                    Value = f.Name
                })
                .ToListAsync();

            return await features;
        }
    }
}
