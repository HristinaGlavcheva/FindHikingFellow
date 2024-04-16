using System.ComponentModel.DataAnnotations;

using static FindHikingFellow.Core.Constants.MessageConstants;
using static FindHikingFellow.Infrastructure.Constants.DataConstants;

namespace FindHikingFellow.Core.Models.Destination
{
    public class DestinationFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DestinationNameMaxLength,
           MinimumLength = DestinationNameMinLength,
            ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty!;

        [Url]
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ImageUrlMaxLength,
            MinimumLength = ImageUrlMinLength,
            ErrorMessage = LengthMessage)]
        public string ImageUrl { get; set; } = string.Empty!;
    }
}