using FindHikingFellow.Core.Models.Feature;
using FindHikingFellow.Core.Models.TourKeyPoint;
using FindHikingFellow.Infrastructure.Data.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Core.Models.Tour
{
    public class TourDetailsServiceModel : TourServiceModel
    {
        public string Description { get; set; } = null!;

        [Display(Name = "Participants")]
        public int ParticipantsCount { get; set; }

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

        [Display(Name="Key Points")]
        public List<string> KeyPoints { get; set; } = new List<string>();

        public List<string> Features { get; set; } = new List<string>();
    }
}
