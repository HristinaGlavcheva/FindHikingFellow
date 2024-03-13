namespace FindHikingFellow.Infrastructure.Data.Models
{
    public class TourFeature
    {
        public int Id { get; init; }

        public int TourId { get; set; }

        public Tour Tour { get; set; } = null!;

        public int FeatureId { get; set; }

        public TourFeature Feature { get; set; } = null!;

    }
}
