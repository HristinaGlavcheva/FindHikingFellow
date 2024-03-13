using Microsoft.AspNetCore.Identity;

namespace FindHikingFellow.Infrastructure.Data.Models
{
    public class TourParticipant
    {
        public int Id { get; init; }

        public int TourId { get; set; }

        public Tour Tour { get; set; } = null!;

        public int ParticipantId { get; set; }

        public IdentityUser Participant { get; set; } = null!;
    }
}
