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

        public async Task<IEnumerable<DestinationServiceModel>> GetMostPopularDestinationsAsync()
        {
            var destinations = repository
               .AllAsNoTracking<Destination>()
               .OrderByDescending(d => d.Tours.Count())
               .Take(3)
               .Select(d => new DestinationServiceModel
               {
                   Name = d.Name,
                   ImageUrl = d.ImageUrl,
               })
               .ToListAsync();

            return await destinations;
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
