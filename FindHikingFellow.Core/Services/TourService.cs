using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Enumerations;
using FindHikingFellow.Core.Models.Tour;
using FindHikingFellow.Core.Models.TourKeyPoint;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FindHikingFellow.Core.Services
{
    public class TourService : ITourService
    {
        private readonly IRepository tourRepository;
        private readonly IRepository keyPointRepository;

        public TourService(
            IRepository _tourRepository,
            IRepository _keyPointRepository)
        {
            tourRepository = _tourRepository;
            keyPointRepository = _keyPointRepository;
        }

        public async Task<TourQueryServiceModel> AllAsync(
            string? destination = null,
            string? searchTerm = null,
            TourSorting sorting = TourSorting.Newest,
            int currentPage = 1,
            int toursPerPage = 3)
        {
            var toursToShow = tourRepository.AllAsNoTracking<Tour>();

            if (!string.IsNullOrWhiteSpace(destination))
            {
                toursToShow = toursToShow
                    .Where(t => t.Destination.Name == destination);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                toursToShow = toursToShow
                    .Where(t =>
                    t.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    t.Description.ToLower().Contains(searchTerm.ToLower()) ||
                    t.Destination.Name.ToLower().Contains(searchTerm.ToLower()) ||
                    t.MeetingPoint.ToLower().Contains(searchTerm.ToLower()));
            }

            toursToShow = sorting switch
            {
                TourSorting.Soonest => toursToShow.Where(t => t.MeetingTime >= DateTime.Now).OrderBy(t => t.MeetingTime).ThenBy(t => t.Name),
                TourSorting.MostPopular => toursToShow.OrderByDescending(t => t.Participants.Count).ThenByDescending(t => t.Id),
                TourSorting.Finished => toursToShow.Where(t => t.MeetingTime < DateTime.Now).OrderBy(t => t.MeetingTime).ThenBy(t => t.Name),
                TourSorting.Newest or _ => toursToShow.OrderByDescending(t => t.Id)
            };

            var tourKeyPoints = keyPointRepository
                .AllAsNoTracking<TourKeyPoint>()
                .Where(tkp => tkp.KeyPoint.Name.Contains(searchTerm));

            var toursByKeyPoints = await tourKeyPoints
                .Select(tkp => new TourServiceModel
                {
                    Id = tkp.TourId,
                    ImageUrl = tkp.Tour.ImageUrl,
                    Name = tkp.Tour.Name,
                    Destination = tkp.Tour.Destination.Name,
                    MeetingTime = tkp.Tour.MeetingTime,
                    Upcoming = tkp.Tour.MeetingTime > DateTime.Now
                }).ToListAsync();

            var totalTours = await toursToShow.CountAsync();

            var tours = await toursToShow
                .Skip((currentPage - 1) * toursPerPage)
                .Take(toursPerPage)
                .ProjectToTourServiceModel()
                .ToListAsync();


            tours.AddRange(toursByKeyPoints);
            var uniqueTours = tours.GroupBy(t => t.Id).Select(x => x.FirstOrDefault());

            return new TourQueryServiceModel
            {
                TotalToursCount = totalTours,
                Tours = uniqueTours
            };
        }

        public async Task<IEnumerable<string>> AllDestinationsNamesAsync()
        {
            return await tourRepository.AllAsNoTracking<Destination>()
                .Select(d => d.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourServiceModel>> AllToursByOrganiserId(string userId)
        {
            return await tourRepository
                .AllAsNoTracking<Tour>()
                .Where(t => t.OrganiserId == userId)
                .ProjectToTourServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<TourServiceModel>> AllToursByUserId(string userId)
        {
            return await tourRepository
                .AllAsNoTracking<Tour>()
                .Where(t => t.Participants.Any(tp => tp.ParticipantId == userId))
                .ProjectToTourServiceModel()
                .ToListAsync();
        }

        public async Task<int> CreateTourAsync(TourFormModel input, string organiserId)
        {
            var newTour = new Tour
            {
                Name = input.Name,
                ImageUrl = input.ImageUrl,
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
                var keyPoint = keyPointRepository
                    .AllAsNoTracking<KeyPoint>()
                    .FirstOrDefault(kp => kp.Name == inputKeyPoint.KeyPointName);

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

        public async Task<bool> ExistsAsync(int id)
        {
            return await tourRepository
                .AllAsNoTracking<Tour>()
                .AnyAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TourViewModel>> GetSoonestUpcomingToursAsync()
        {
            var tours = tourRepository
                .AllAsNoTracking<Tour>()
                .OrderByDescending(t => t.MeetingTime)
                .Select(t => new TourViewModel
                {
                    Name = t.Name,
                    ImageUrl = t.Destination.ImageUrl,
                })
                .ToListAsync();

            return await tours;
        }

        public async Task<TourDetailsServiceModel> TourDetailsByIdAsync(int id)
        {
            return await tourRepository
                .AllAsNoTracking<Tour>()
                .Where(t => t.Id == id)
                .Select(t => new TourDetailsServiceModel
                {
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                    Description = t.Description,
                    Destination = t.Destination.Name,
                    Difficulty = t.Difficulty,
                    Duration = t.Duration,
                    ActivityType = t.ActivityType,
                    ElevationGain = t.ElevationGain,
                    Id = t.Id,
                    Length = t.Length,
                    MeetingPoint = t.MeetingPoint,
                    MeetingTime = t.MeetingTime,
                    RouteType = t.RouteType,
                    Upcoming = t.MeetingTime > DateTime.Now,
                    ParticipantsCount = t.Participants.Count,
                    KeyPoints = t.KeyPoints.Select(t => t.KeyPoint.Name).ToList(),
                    Features = t.Features.Select(t => t.Feature.Name).ToList()
                })
                .FirstAsync();
        }

        public async Task<bool> TourWithSameNameExists(string name)
        {
            return await tourRepository
                .AllAsNoTracking<Tour>()
                .AnyAsync(t => t.Name == name);
        }

        public async Task<bool> IsOrganisedBy(int tourId, string userId)
        {
            return await tourRepository
                .AllAsNoTracking<Tour>()
                .AnyAsync(t => t.Id == tourId && t.OrganiserId == userId);
        }

        public async Task<IEnumerable<TourServiceModel>> GetToursByDestinationAsync(string destination)
        {
            var tours = await tourRepository
                .AllAsNoTracking<Tour>()
                .Where(t => t.Destination.Name == destination)
                .ProjectToTourServiceModel()
                .ToListAsync();

            return tours;
        }

        public async Task EditTourAsync(TourFormModel input, int tourId)
        {
            var tour = await tourRepository.GetByIdAsync<Tour>(tourId);

            if(tour != null)
            {
                tour.Name = input.Name;
                tour.DestinationId = input.DestinationId;
                tour.Description = input.Description;
                tour.Duration = input.Duration;
                tour.Difficulty = input.Difficulty;
                tour.ActivityType = input.ActivityType;
                tour.ElevationGain = input.ElevationGain;
                tour.RouteType = input.RouteType;
                tour.ImageUrl = input.ImageUrl;
                tour.MeetingPoint = input.MeetingPoint;
                tour.MeetingTime = input.MeetingTime;
                tour.Length = input.Length;

                await tourRepository.SaveChangesAsync();
            }
        }

        public async Task<TourFormModel?> GetTourFormModelByIdAsync(int id)
        {
            var tour = await tourRepository
                .AllAsNoTracking<Tour>()
                .Where(t => t.Id == id).FirstOrDefaultAsync();

            var model = new TourFormModel()
            {
                Name = tour.Name,
                ImageUrl = tour.ImageUrl,
                Description = tour.Description,
                Difficulty = tour.Difficulty,
                Duration = tour.Duration,
                ActivityType = tour.ActivityType,
                ElevationGain = tour.ElevationGain,
                Length = tour.Length,
                MeetingPoint = tour.MeetingPoint,
                MeetingTime = tour.MeetingTime,
                RouteType = tour.RouteType,
                DestinationId = tour.DestinationId,
            };

            return model;
        }

        public async Task<IEnumerable<TourKeyPointModel>> ListKeyPointsAsync(int id)
        {
            return await keyPointRepository
                .AllAsNoTracking<TourKeyPoint>()
                .Where(tkp =>tkp.Tour.Id == id)
                .Select(tkp => new TourKeyPointModel()
                {
                    KeyPointName = tkp.KeyPoint.Name
                }).ToListAsync();
        }
    }
}
