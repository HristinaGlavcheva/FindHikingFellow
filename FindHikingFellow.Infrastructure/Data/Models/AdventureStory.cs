using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static FindHikingFellow.Infrastructure.Constants.DataConstants;

namespace FindHikingFellow.Infrastructure.Data.Models
{
    [Comment("Stories/itineraries added by users")]
    public class AdventureStory
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(AdventureStoryTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(AdventureStoryContentMaxLength)]
        public string Content { get; set; } = string.Empty;

        [Comment("The date that the story was published")]
        public DateTime PublishedOn { get; set; }

        [Required]
        public string AuthorId { get; set; } = null!;

        public IdentityUser Author { get; set; } = null!;

        public int DestinationId { get; set; }  

        public Destination Destination { get; set; } = null!;
    }
}
