using FindHikingFellow.Core.Models.Destination;
using FindHikingFellow.Core.Models.Tour;

namespace FindHikingFellow.Core.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<DestinationViewModel> Destinations { get; set; } = null!;

        public IEnumerable<TourViewModel> Tours { get; set; } = null!;
    }
}
