namespace FindHikingFellow.Core.Models
{
    public class IndexViewModel
    {
        public IEnumerable<DestinationViewModel> Destinations { get; set; } = null!;

        public IEnumerable<TourViewModel> Tours { get; set; } = null!;
    }
}
