namespace FindHikingFellow.Core.Models.Tour
{
    public class MyToursServiceModel
    {
        public IEnumerable<TourServiceModel> Organised { get; set; } = new HashSet<TourServiceModel>();

        public IEnumerable<TourServiceModel> Joined { get; set; } = new HashSet<TourServiceModel>();
    }
}
