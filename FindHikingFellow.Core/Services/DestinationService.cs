using Microsoft.EntityFrameworkCore;
using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models;
using FindHikingFellow.Core.Models.Destination;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;

namespace FindHikingFellow.Core.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IRepository destinationRepository;
        private readonly IRepository tourRepository;

        public DestinationService(IRepository _destinationRepository, IRepository _tourRepository)
        {
            destinationRepository = _destinationRepository;
            tourRepository = _tourRepository;
        }

        public async Task<IEnumerable<DestinationViewModel>> GetMostPopularDestinationsAsync()
        {
            var destinations = destinationRepository
               .AllAsNoTracking<Destination>()
               .Where(d => !d.IsDeleted)
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
               .Where(d => !d.IsDeleted)
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
                .Where(d => !d.IsDeleted)
                .Select(d => new ListDestinationsViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                })
                .ToListAsync();

            return await destinations;
        }

        public async Task<int> AddDestinationAsync(DestinationFormModel input)
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

        public async Task<DestinationFormModel?> GetDestinationFormModelByIdAsync(int id)
        {
            var destination = await destinationRepository
                .AllAsNoTracking<Destination>()
                 .Where(d => !d.IsDeleted)
                .Where(d => d.Id == id).FirstOrDefaultAsync();

            var model = new DestinationFormModel
            {
                Name = destination.Name,
                ImageUrl = destination.ImageUrl
            };

            return model;
        }

        public async Task EditDestinationAsync(DestinationFormModel input, int id)
        {
            var destination = await destinationRepository.GetByIdAsync<Destination>(id);

            if(destination != null)
            {
                destination.Name = input.Name;
                destination.ImageUrl = input.ImageUrl;

                await destinationRepository.SaveChangesAsync();
            }
        }

        public async Task<DestinationFormModel> DestinationToBeDeletedById(int id)
        {
            var destination = await destinationRepository
                .AllAsNoTracking<Destination>()
                .Where(d => d.Id == id && !d.IsDeleted)
                .Select(d => new DestinationFormModel
                {
                    Name = d.Name,
                    ImageUrl = d.ImageUrl
                }).FirstAsync();

            return destination;
        }

        public async Task<int> DeleteDestinationByIdAsync(int id)
        {
            Destination destinationToDelete = await destinationRepository
                .All<Destination>()
                .Where(d => !d.IsDeleted)
                .FirstAsync(d => d.Id == id);

            if (await DestinationHasTours(id) == false)
            {
                destinationToDelete.IsDeleted = true;
                await destinationRepository.SaveChangesAsync();
            }

            return id;
        }

        public async Task<bool> DestinationHasTours(int id)
        {
            var tours = await tourRepository
                .AllAsNoTracking<Tour>()
                .Where (t => t.DestinationId == id && !t.IsDeleted)
                .ToListAsync();

            return tours.Count > 0;
        }
    }
}
