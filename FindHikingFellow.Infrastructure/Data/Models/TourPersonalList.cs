namespace FindHikingFellow.Infrastructure.Data.Models
{
    public class TourPersonalList
    {
        public int Id { get; init; }

        public int TourId { get; set; }

        public Tour Tour { get; set; } = null!;

        public int PersonalListId { get; set; }

        public TourFeature PersonalList { get; set; } = null!;
    }
}
