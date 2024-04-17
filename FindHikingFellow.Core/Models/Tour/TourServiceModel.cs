using System.ComponentModel.DataAnnotations;
using FindHikingFellow.Core.Contracts;

namespace FindHikingFellow.Core.Models.Tour
{
    public class TourServiceModel : ITourModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Destination { get; set; } = string.Empty;

        [Display(Name = "Full Name")]   
        public string OrganiserName { get; set; } = string.Empty;

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime MeetingTime { get; set; }

        public bool Upcoming { get; set; }
    }
}
