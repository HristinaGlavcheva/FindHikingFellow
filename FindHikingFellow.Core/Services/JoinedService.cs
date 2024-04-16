using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Admin;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FindHikingFellow.Core.Services
{
    public class JoinedService : IJoinedService
    {
        private readonly IRepository tourRepository;

        public JoinedService(IRepository _tourRepository)
        {
            tourRepository = _tourRepository;
        }

        public async Task<IEnumerable<JoinedServiceModel>> AllAsync()
        {
            return await tourRepository
                .AllAsNoTracking<Tour>()
                .Where(t => t.Participants.Any())
                .Select(t => new JoinedServiceModel
                {
                    TourName = t.Name,
                    TourImageUrl = t.ImageUrl,
                    OrganiserFullName = $"{t.Organiser.FirstName} {t.Organiser.LastName}",
                    OrganiserEmail = t.Organiser.Email,
                    Participants = t.Participants.Select(tp => new ParticipantServiceModel
                    {
                        ParticipantFullName = $"{tp.Participant.FirstName} {tp.Participant.LastName}",
                        ParticipantEmail = tp.Participant.Email
                    })
                })
                .ToListAsync();
        }
    }
}
