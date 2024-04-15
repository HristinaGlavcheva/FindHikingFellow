using System.ComponentModel.DataAnnotations;

using static FindHikingFellow.Infrastructure.Constants.DataConstants;

namespace FindHikingFellow.Infrastructure.Data.Models
{
    public class PersonalList
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(PersonalListNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<TourPersonalList> Tours { get; init; } = new HashSet<TourPersonalList>();
    }
}
