using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models;
using FindHikingFellow.Core.Models.Destination;
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

        public async Task<IEnumerable<AddDestinationFormModel>> GetMostPopularDestinationsAsync()
        {
            var destinations = destinationRepository
               .AllAsNoTracking<Destination>()
               .OrderByDescending(d => d.Tours.Count())
               .Take(6)
               .Select(d => new AddDestinationFormModel
               {
                   Name = d.Name,
                   ImageUrl = d.ImageUrl,
               })
               .ToListAsync();

            return await destinations;
        }

        public async Task<AllDestinationsViewModel> GetAllDestinationsAsync()
        {
            var destinations = await destinationRepository
               .AllAsNoTracking<Destination>()
               .OrderBy(d => d.Name)
               .Select(d => new AddDestinationFormModel
               {
                   Name = d.Name,
                   ImageUrl = d.ImageUrl,
               })
               .ToListAsync();

            var allDestinationsViewModel = new AllDestinationsViewModel
            {
                AllDestinations = destinations
            };

            return allDestinationsViewModel;
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

        public async Task<bool> DestinationExistsByNameAsync(string destinationName)
        {
            return await destinationRepository
                .AllAsNoTracking<Destination>()
                .AnyAsync(d => d.Name == destinationName);
        }

    }
}
