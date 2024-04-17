using Microsoft.EntityFrameworkCore;
using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Statistics;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;

namespace FindHikingFellow.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository tourRepository;
        private readonly IRepository tourParticipantsRepository;

        public StatisticService(IRepository _tourRepository, IRepository _tourParticipantsRepository)
        {
            tourRepository = _tourRepository;
            tourParticipantsRepository = _tourParticipantsRepository;
        }

        public async Task<StatisticServiceModel> TotalAsync()
        {
            var totalTours = await tourRepository
                .AllAsNoTracking<Tour>()
                .Where(t => t.IsApproved)
                .CountAsync();

            var totalParticipants = await tourParticipantsRepository
                .AllAsNoTracking<TourParticipant>()
                .CountAsync();

            return new StatisticServiceModel
            {
                TotalTours = totalTours,
                TotalParticipants = totalParticipants
            };
        }
    }
}
