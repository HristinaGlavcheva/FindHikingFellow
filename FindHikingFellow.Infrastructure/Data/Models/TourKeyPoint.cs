namespace FindHikingFellow.Infrastructure.Data.Models
{
    public class TourKeyPoint

    {
        public int TourId { get; set; }

        public Tour Tour { get; set; } = null!;

        public int KeyPointId { get; set; }

        public KeyPoint KeyPoint { get; set; } = null!;
    }
}
