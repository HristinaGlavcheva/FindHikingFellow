using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models;
using FindHikingFellow.Core.Models.Destination;
using FindHikingFellow.Core.Models.Tour;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FindHikingFellow.Core.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository destinationRepository;

        public DestinationService(IRepository _destinationRepository)
        {
            destinationRepository = _destinationRepository;
        }

        public async Task<IEnumerable<DestinationViewModel>> GetMostPopularDestinationsAsync()
        {
            var destinations = destinationRepository
               .AllAsNoTracking<Destination>()
               .OrderByDescending(d => d.Tours.Count())
               .Take(3)
               .Select(d => new DestinationViewModel
               {
                   Id = d.Id,
                   Name = d.Name,
                   ImageUrl = d.ImageUrl,
               })
               .ToListAsync();

            return await destinations;
        }

        public async Task<IEnumerable<DestinationViewModel>> GetAllDestinationsAsync()
        {
            var destinations = await destinationRepository
               .AllAsNoTracking<Destination>()
               .OrderBy(d => d.Name)
               .Select(d => new DestinationViewModel
               {
                   Id = d.Id,
                   Name = d.Name,
                   ImageUrl = d.ImageUrl,
               })
               .ToListAsync();

            return destinations;
        }

        public async Task<IEnumerable<ListDestinationsViewModel>> ListDestinationsAsync()
        {
            var destinations = destinationRepository
                .AllAsNoTracking<Destination>()
                .Select(d => new ListDestinationsViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                })
                .ToListAsync();

            return await destinations;
        }

        public async Task<int> AddDestinationAsync(AddDestinationFormModel input)
        {
            var newDestination = new Destination
            {
                Name = input.Name,
                ImageUrl = input.ImageUrl
            };

            await destinationRepository.AddAsync(newDestination);
            await destinationRepository.SaveChangesAsync();

            return newDestination.Id;
        }

        public async Task<bool> DestinationExistsByIdAsync(int destinationId)
        {
            return await destinationRepository
                .AllAsNoTracking<Destination>()
                .AnyAsync(d => d.Id == destinationId);
        }

        public async Task<bool> DestinationExistsByNameAsync(string destination)
        {
            return await destinationRepository
                .AllAsNoTracking<Destination>()
                .AnyAsync(d => d.Name == destination);
        }
    }
}
