using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Core.Models.PersonalList
{
    public class AddToListFormModel
    {
        [Display(Name = "List")]
        public int ListId { get; set; }

        public IEnumerable<ListViewModel> Lists { get; set; } = new HashSet<ListViewModel>();
    }
}
