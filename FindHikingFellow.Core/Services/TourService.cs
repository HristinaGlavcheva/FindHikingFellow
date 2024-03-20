using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models;
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
        public async Task<IEnumerable<TourServiceModel>> GetMostResentToursAsync()
        {
            var tours = tourRepository
                .AllAsNoTracking<Tour>()
                .OrderByDescending(t => t.Id)
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
