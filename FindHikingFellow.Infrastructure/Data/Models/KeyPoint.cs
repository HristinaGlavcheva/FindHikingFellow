using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static FindHikingFellow.Infrastructure.Constants.DataConstants;

namespace FindHikingFellow.Infrastructure.Data.Models
{
    [Comment("Specific point or place that the tour moves through or near by")]
    public class KeyPoint
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(KeyPointNameMaxLength)]
        public string Name { get; set; } = string.Empty;    

        public ICollection<TourKeyPoint> Tours { get; init; } = new HashSet<TourKeyPoint>();
    }
}
