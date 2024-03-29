﻿using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Enumerations;
using FindHikingFellow.Core.Models.Tour;
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

            if(!string.IsNullOrWhiteSpace(destination))
            {
                toursToShow = toursToShow
                    .Where(t => t.Destination.Name == destination);
            }

            if(!string.IsNullOrWhiteSpace(searchTerm))
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
                TourSorting.Soonest => toursToShow.Where(t=> t.MeetingTime >= DateTime.Now).OrderBy(t => t.MeetingTime).ThenBy(t=>t.Name),
                TourSorting.MostPopular => toursToShow.OrderByDescending(t => t.Participants.Count).ThenByDescending(t => t.Id),
                TourSorting.Finished => toursToShow.Where(t => t.MeetingTime < DateTime.Now).OrderBy(t => t.MeetingTime).ThenBy(t => t.Name),
                TourSorting.Newest or _=> toursToShow.OrderByDescending(t => t.Id)
            };

            var tourKeyPoints = keyPointRepository.AllAsNoTracking<TourKeyPoint>().Where(tkp => tkp.KeyPoint.Name.Contains(searchTerm));
            var toursByKeyPoints = await tourKeyPoints.Select(t => new TourServiceModel
            {
                Id = t.TourId,
                Name = t.Tour.Name,
                Destination = t.Tour.Destination.Name,
                MeetingTime = t.Tour.MeetingTime,
                ParticipantsCount = t.Tour.Participants.Count,
                Upcoming = t.Tour.MeetingTime > DateTime.Now
            }).ToListAsync();

            var totalTours = await toursToShow.CountAsync();

            var tours = await toursToShow
                .Skip((currentPage - 1) * toursPerPage)
                .Take(toursPerPage)
                .Select(t => new TourServiceModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                    Destination = t.Destination.Name,
                    MeetingTime = t.MeetingTime.Date,
                    ParticipantsCount = t.Participants.Count,
                    Upcoming = t.MeetingTime > DateTime.Now
                }).ToListAsync();


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

        public async Task<int> CreateTourAsync(CreateTourFormModel input, string organiserId)
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

        public async Task<bool> TourWithSameNameExists(string name)
        {
            return await tourRepository
                .AllAsNoTracking<Tour>()
                .AnyAsync(t => t.Name == name);
        }
    }
}
