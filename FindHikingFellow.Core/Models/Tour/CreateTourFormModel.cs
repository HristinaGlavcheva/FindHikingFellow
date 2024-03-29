using FindHikingFellow.Attributes;
using FindHikingFellow.Core.Models.Feature;
using FindHikingFellow.Core.Models.TourKeyPoint;
using FindHikingFellow.Infrastructure.Data.Models;
using FindHikingFellow.Infrastructure.Data.Models.Enumerations;
using System.ComponentModel.DataAnnotations;
using static FindHikingFellow.Core.Constants.MessageConstants;
using static FindHikingFellow.Infrastructure.Constants.DataConstants;


namespace FindHikingFellow.Core.Models.Tour
{
    public class CreateTourFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TourNameMaxLength,
           MinimumLength = TourNameMinLength,
            ErrorMessage = LengthMessage)]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = TourNameRegexMessage)]
        public string Name { get; set; } = null!;

        [Url]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ImageUrlMaxLength,
            MinimumLength = ImageUrlMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name="Image URL")]
        public string ImageUrl { get; set; } = string.Empty!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TourDescriptionMaxLength,
            MinimumLength = TourDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;

        [Display(Name = "Length in km")]
        public double? Length { get; set; }

        [Display(Name = "Elevation gain in meters")]
        public int? ElevationGain { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string Duration { get; set; } = null!;

        [Display(Name = "Meeting time")]
        [IsInTheFuture(ErrorMessage = "Meeting time should be in the future")]
        public DateTime MeetingTime { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TourMeetingPointMaxLength,
            MinimumLength = TourMeetingPointMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Meeting Point")]
        public string MeetingPoint { get; set; } = null!;

        [Display(Name = "Rout Type")]
        public RouteType RouteType { get; set; }

        public Difficulty Difficulty { get; set; }

        [Display(Name = "Activity Type")]
        public ActivityType ActivityType { get; set; }

        [Display(Name = "Destination")]
        public int DestinationId { get; set; }

        public IEnumerable<ListDestinationsViewModel> Destinations { get; set; } = new HashSet<ListDestinationsViewModel>();

        public IEnumerable<TourKeyPointInputModel> KeyPoints { get; set; } = new HashSet<TourKeyPointInputModel>();

        public List<ListFeaturesViewModel> Features { get; set; } = new List<ListFeaturesViewModel>();

        public ICollection<Image> Images { get; init; } = new HashSet<Image>();
    }
}
