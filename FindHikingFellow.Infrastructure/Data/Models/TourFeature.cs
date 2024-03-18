namespace FindHikingFellow.Infrastructure.Data.Models
{
    public class TourFeature
    {
        public int TourId { get; set; }

        public Tour Tour { get; set; } = null!;

        public int FeatureId { get; set; }

        public Feature Feature { get; set; } = null!;
    }
}
