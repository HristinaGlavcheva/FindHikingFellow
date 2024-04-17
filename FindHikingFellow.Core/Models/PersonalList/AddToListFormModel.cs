namespace FindHikingFellow.Core.Models.PersonalList
{
    public class AddToListFormModel
    {
        public int ListId { get; set; }


        public int UserId { get; set; }

        public IEnumerable<ListNameViewModel> Lists { get; set; } = new HashSet<ListNameViewModel>();
    }
}
