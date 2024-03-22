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
        private readonly IRepository repository;

        public DestinationService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<DestinationViewModel>> GetMostPopularDestinationsAsync()
        {
            var destinations = repository
               .AllAsNoTracking<Destination>()
               .OrderByDescending(d => d.Tours.Count())
               .Take(6)
               .Select(d => new DestinationViewModel
               {
                   Name = d.Name,
                   ImageUrl = d.ImageUrl,
               })
               .ToListAsync();

            return await destinations;
        }

        public async Task<AllDestinationsViewModel> GetAllDestinationsAsync()
        {
            var destinations = await repository
               .AllAsNoTracking<Destination>()
               .OrderBy(d => d.Name)
               .Select(d => new DestinationViewModel
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
            var destinations = repository
                .AllAsNoTracking<Destination>()
                .Select(d => new ListDestinationsViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                })
                .ToListAsync();

            return await destinations;
        }
    }
}
