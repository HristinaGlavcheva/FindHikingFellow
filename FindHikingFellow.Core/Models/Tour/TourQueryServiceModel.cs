namespace FindHikingFellow.Core.Models.Tour
{
    public class TourQueryServiceModel
    {
        public int TotalToursCount { get; set; }

        public IEnumerable<TourServiceModel> Tours { get; set; } = new HashSet<TourServiceModel>();
    }
}
