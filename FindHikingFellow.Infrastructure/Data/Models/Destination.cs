﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static FindHikingFellow.Infrastructure.Constants.DataConstants;

namespace FindHikingFellow.Infrastructure.Data.Models
{
    [Comment("Mountain or region that the tour moves through")]
    public class Destination
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DestinationNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Url]
        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }

        public ICollection<Tour> Tours { get; set; } = new HashSet<Tour>();
    }
}
