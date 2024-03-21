using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Tour;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FindHikingFellow.Core.Services
{
    public class TourService : ITourService
    {
        private readonly IRepository tourRepository;

        public TourService(IRepository _tourRepository)
        {
            tourRepository = _tourRepository;
        }

        public async Task<CreateTourFormModel> CreateTourAsync(CreateTourFormModel input, string organiserId    )
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
            };

            await tourRepository.AddAsync(newTour);
            await tourRepository.SaveChangesAsync();
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
    }
}
