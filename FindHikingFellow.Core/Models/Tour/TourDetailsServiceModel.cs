using FindHikingFellow.Core.Models.Feature;
using FindHikingFellow.Core.Models.Feedback;
using FindHikingFellow.Core.Models.PersonalList;
using FindHikingFellow.Infrastructure.Data.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Core.Models.Tour
{
    public class TourDetailsServiceModel : TourServiceModel
    {
        public string Description { get; set; } = null!;

        [Display(Name = "Participants")]
        public int ParticipantsCount { get; set; } = 1;

        [Display(Name = "Length in km")]
        public double? Length { get; set; }

        [Display(Name = "Elevation gain in meters")]
        public int? ElevationGain { get; set; }

        public string Duration { get; set; } = null!;

        [Display(Name = "Meeting Point")]
        public string MeetingPoint { get; set; } = null!;
       
        [Display(Name = "Rout Type")]
        public RouteType RouteType { get; set; }

        public Difficulty Difficulty { get; set; }

        [Display(Name = "Activity Type")]
        public ActivityType ActivityType { get; set; }

        public double Rating { get; set; }

        [Range(1.0, 5.0)]
        public double AverageRating { get; set; }

        [Display(Name="Key Points")]
        public List<string> KeyPoints { get; set; } = new List<string>();

        public List<FeatureViewModel> Features { get; set; } = new List<FeatureViewModel>();

        public List<FeedbackViewModel> Feedbacks { get; set; } = new List<FeedbackViewModel>();

        public List<ListNameViewModel> Lists { get; set; } = new List<ListNameViewModel>();

    }
}
