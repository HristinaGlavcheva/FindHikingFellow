using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Feature;
using FindHikingFellow.Core.Models.Tour;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FindHikingFellow.Core.Services
{
    public class TourService : ITourService
    {
        private readonly IRepository tourRepository;
        private readonly IRepository featureRepository;
        private readonly IRepository keyPointRepository;

        public TourService(
            IRepository _tourRepository,
            IRepository _featureRepository,
            IRepository _keyPointRepository)
        {
            tourRepository = _tourRepository;
            featureRepository = _featureRepository;
            keyPointRepository = _keyPointRepository;
        }

        public async Task<int> CreateTourAsync(CreateTourFormModel input, string organiserId)
        {
            var newTour = new Tour
            {
                Name = input.Name,
                Description = input.Description,
                DestinationId = input.DestinationId,
                Difficulty = input.Difficulty,
                Duration = input.Duration,
                RouteType = input.RouteType,
                MeetingPoint = input.MeetingPoint,
                MeetingTime = input.MeetingTime,
                ActivityType = input.ActivityType,
                ElevationGain = input.ElevationGain,
                Length = input.Length,
                OrganiserId = organiserId,
                Features = input.Features.Select(f => new TourFeature
                {
                    FeatureId = f.Id,

                }).ToList()
            };

            foreach (var inputKeyPoint in input.KeyPoints)
            {
                var keyPoint = keyPointRepository.AllAsNoTracking<KeyPoint>().FirstOrDefault(kp => kp.Name == inputKeyPoint.KeyPointName);
                if (keyPoint == null)
                {
                    keyPoint = new KeyPoint { Name = inputKeyPoint.KeyPointName };
                }

                newTour.KeyPoints.Add(new TourKeyPoint { KeyPoint = keyPoint });
            }

            foreach (var inputFeature in input.Features)
            {
                var feature = new Feature
                {
                    Name = inputFeature.Name
                };

                newTour.Features.Add(new TourFeature { Feature = feature });
            }

            await tourRepository.AddAsync(newTour);
    await tourRepository.SaveChangesAsync();

            return newTour.Id;
        }

public async Task<IEnumerable<TourServiceModel>> GetMostResentToursAsync()
{
    var tours = tourRepository
        .AllAsNoTracking<Tour>()
        .OrderByDescending(t => t.MeetingTime)
        .Select(t => new TourServiceModel
        {
            Name = t.Name,
            ImageUrl = t.Destination.ImageUrl,
        })
        .ToListAsync();

    return await tours;
}

public async Task<bool> TourWithSameNameExists(string name)
{
    return await tourRepository
        .AllAsNoTracking<Tour>()
        .AnyAsync(t => t.Name == name);
}
    }
}
