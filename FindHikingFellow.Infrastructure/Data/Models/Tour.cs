using FindHikingFellow.Infrastructure.Data.Models.Enumerations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FindHikingFellow.Infrastructure.Constants.DataConstants;

namespace FindHikingFellow.Infrastructure.Data.Models
{
    public class Tour
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(TourNameMaxLength)]
        [RegularExpression("[A-Z][^_]+")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(TourDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Comment("The length of the trail in km")]
        public double? Length { get; set; }

        [Comment("The elevation gain in meters")]
        public int? ElevationGain { get; set; }

        [Required]
        public string Duration { get; set; } = string.Empty;

        [Comment("The time when the participants are supposed to meet to begin tour")]
        public DateTime MeetingTime { get; set; }

        [Required]
        [MaxLength(TourMeetingPointMaxLength)]
        [Comment("The point where the participants are supposed to meet to begin tour")]
        public string MeetingPoint { get; set; } = string.Empty;

        public RouteType RouteType { get; set; }

        public Difficulty Difficulty { get; set; }

        public ActivityType ActivityType { get; set; }

        public int DestinationId { get; set; }

        [Comment("The mountain or region the tour is located")]
        public Destination Destination { get; set; } = null!;
                
        [Required]
        public string OrganiserId { get; set; } = null!;

        [Comment("The User who added the tour")]
        public IdentityUser Organiser { get; set; } = null!;

        [Comment("Specific points or places which the tour is going to pass near by")]
        public ICollection<TourKeyPoint> KeyPoints { get; init; } = new HashSet<TourKeyPoint>();

        [Comment("Some additional distinctive features of the tour")]
        public ICollection<TourFeature> Features { get; init; } = new HashSet<TourFeature>();

        [Comment("Different users' lists of tours where the tour is included")]
        public ICollection<TourPersonalList> PersonalLists { get; init; } = new HashSet<TourPersonalList>();

        //[Comment("Helpful advices, warnings, tips and tricks about the tour")]
        //public ICollection<TipsAndTricks> TipsAndTricks { get; init; } = new HashSet<TipsAndTricks>();

        [Comment("Ratings and review of the tour")]
        public ICollection<FeedBack> FeedBacks { get; init; } = new HashSet<FeedBack>();

        public ICollection<TourParticipant> Participants { get; init; } = new HashSet<TourParticipant>();
       
        public ICollection<Image> Images { get; init; } = new HashSet<Image>();
    }
}
