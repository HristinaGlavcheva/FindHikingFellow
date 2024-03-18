namespace FindHikingFellow.Infrastructure.Data.Models
{
    public class TourPersonalList
    {
        public int TourId { get; set; }

        public Tour Tour { get; set; } = null!;

        public int PersonalListId { get; set; }

        public PersonalList PersonalList { get; set; } = null!;
    }
}
