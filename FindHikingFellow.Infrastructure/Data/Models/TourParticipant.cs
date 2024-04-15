using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Infrastructure.Data.Models
{
    public class TourParticipant
    {
        public int TourId { get; set; }

        public Tour Tour { get; set; } = null!;

        [Required]
        public string ParticipantId { get; set; } = string.Empty;   

        public ApplicationUser Participant { get; set; } = null!;
    }
}
