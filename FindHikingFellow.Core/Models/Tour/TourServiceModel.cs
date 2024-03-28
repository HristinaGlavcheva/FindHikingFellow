using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Core.Models.Tour
{
    public class TourServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Destination { get; set; } = string.Empty;

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime MeetingTime { get; set; }

        [Display(Name="Participants")]
        public int ParticipantsCount { get; set; }

        public bool Upcoming { get; set; }
    }
}
