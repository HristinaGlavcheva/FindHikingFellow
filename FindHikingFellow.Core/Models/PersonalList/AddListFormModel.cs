using System.ComponentModel.DataAnnotations;
using static FindHikingFellow.Core.Constants.MessageConstants;
using static FindHikingFellow.Infrastructure.Constants.DataConstants;

namespace FindHikingFellow.Core.Models.PersonalList
{
    public class AddListFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PersonalListNameMaxLength,
         MinimumLength = PersonalListNameMinLength,
         ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty!;
    }
}
