using FindHikingFellow.Core.Contracts;

namespace FindHikingFellow.Core.Models.Tour
{
    public class TourToBeDeletedServiceModel : ITourModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Destination { get; set; } = string.Empty;

    }
}
