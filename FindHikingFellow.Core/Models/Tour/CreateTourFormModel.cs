﻿using FindHikingFellow.Infrastructure.Data.Models.Enumerations;
using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FindHikingFellow.Core.Constants.MessageConstants;
using static FindHikingFellow.Infrastructure.Constants.DataConstants;
using FindHikingFellow.Core.Models.Destination;


namespace FindHikingFellow.Core.Models.Tour
{
    public class CreateTourFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TourNameMaxLength,
           MinimumLength = TourNameMinLength,
            ErrorMessage = LengthMessage)]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = TourNameRegexMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TourDescriptionMaxLength,
            MinimumLength = TourDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;

        [Display(Name = "Length in km")]
        public double? Length { get; set; }

        [Display(Name = "Elevation gain in meters")]
        public int? ElevationGain { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string Duration { get; set; } = null!;

        [Display(Name = "Meeting time")]
        public DateTime MeetingTime { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TourMeetingPointMaxLength,
            MinimumLength = TourMeetingPointMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Meeting Point")]
        public string MeetingPoint { get; set; } = null!;

        [Display(Name = "Rout Type")]
        public RouteType RouteType { get; set; }

        public Difficulty Difficulty { get; set; }

        [Display(Name = "Activity Type")]
        public ActivityType ActivityType { get; set; }

        [Display(Name = "Destination")]
        public int DestinationId { get; set; }

        public IEnumerable<ListDestinationsViewModel> Destinations { get; set; } = new HashSet<ListDestinationsViewModel>();

        public ICollection<Image> Images { get; init; } = new HashSet<Image>();
    }
}
