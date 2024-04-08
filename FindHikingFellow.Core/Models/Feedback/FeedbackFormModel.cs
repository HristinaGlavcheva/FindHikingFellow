using FindHikingFellow.Infrastructure.Data.Models.Enumerations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace FindHikingFellow.Core.Models.Feedback
{
    using Tour = Infrastructure.Data.Models.Tour;

    public class FeedbackFormModel
    {
        [Range(1, 5)]
        public int Rate { get; set; }

        public string Review { get; set; } = string.Empty;

        public ActivityType ActivityType { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
