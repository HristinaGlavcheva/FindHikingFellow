using System.ComponentModel.DataAnnotations;

using static FindHikingFellow.Core.Constants.MessageConstants;
using static FindHikingFellow.Infrastructure.Constants.DataConstants;


namespace FindHikingFellow.Core.Models.PersonalList
{
    public class AddToListFormModel
    {
        public int ListId { get; set; }


        public int UserId { get; set; }

        public IEnumerable<ListViewModel> Lists { get; set; } = new HashSet<ListViewModel>();
    }
}
