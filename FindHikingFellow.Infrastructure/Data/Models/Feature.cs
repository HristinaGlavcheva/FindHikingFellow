using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static FindHikingFellow.Infrastructure.Constants.DataConstants;

namespace FindHikingFellow.Infrastructure.Data.Models
{
    [Comment("Additional distinctive feature of the tour")]
    public class Feature
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(FeatureNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<TourFeature> Tours { get; init; } = new HashSet<TourFeature>();
    }
}
