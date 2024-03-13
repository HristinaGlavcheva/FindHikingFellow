using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Infrastructure.Data.Models
{
    public class Image
    {
        public int Id { get; init; }

        [Required]
        [Comment("Extension of the image file")]
        public string Extension { get; set; } = string.Empty;

        [Required]
        public string AddedByUserId { get; set; } = string.Empty;

        [Comment("The user that added the Image")]
        public IdentityUser AddedByUser { get; set; } = null!;

        public int TourId { get; set; }

        [Comment("The tour that the image is corresponding to")]
        public Tour Tour { get; set; } = null!;
    }
}
