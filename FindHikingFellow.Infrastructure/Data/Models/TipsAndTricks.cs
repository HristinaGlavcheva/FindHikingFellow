using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FindHikingFellow.Infrastructure.Constants.DataConstants;

namespace FindHikingFellow.Infrastructure.Data.Models
{
    [Comment("Helpful advises, warnings, tips and tricks about the tour")]
    public class TipsAndTricks
    {
        public int Id { get; init; }

        public Destination Destination { get; set; } = null!;

        [Required]
        [MaxLength(TipsAndTricksContentMaxLength)]
        public string Content { get; set; } = string.Empty;
    }
}
