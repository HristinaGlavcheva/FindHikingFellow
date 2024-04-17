using FindHikingFellow.Infrastructure.Attributes;
using FindHikingFellow.Infrastructure.Data.Models.Enumerations;
using System.ComponentModel.DataAnnotations;


namespace FindHikingFellow.Core.Models.Feedback
{
    public class FeedbackFormModel
    {
        [Range(1, 5)]
        public int Rate { get; set; }

        [Required]
        public string Review { get; set; } = string.Empty;

        public ActivityType ActivityType { get; set; }

        [HasPassed(ErrorMessage = "Completed on should be passed in the last 20 years")]
        public DateTime CompletedOn { get; set; }
    }
}
