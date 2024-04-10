using FindHikingFellow.Core.Models.Tour;

namespace FindHikingFellow.Core.Models.PersonalList
{
    public class MyListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<TourServiceModel> Tours { get; set; } = new List<TourServiceModel>();
    }
}
