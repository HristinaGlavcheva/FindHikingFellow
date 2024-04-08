using FindHikingFellow.Infrastructure.Data.Models.Enumerations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Infrastructure.Data.Models
{
    public class FeedBack
    {
        public int Id { get; init; }

        [Range(0, 5)]
        public double Rate { get; set; }

        public string Review { get; set; } = string.Empty;

        public ActivityType ActivityType { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int TourId { get; set; }

        public Tour Tour { get; set; } = null!;

        [Required]
        public string AuthorId { get; set; } = null!;

        public IdentityUser Author { get; set; } = null!;
    }
}
