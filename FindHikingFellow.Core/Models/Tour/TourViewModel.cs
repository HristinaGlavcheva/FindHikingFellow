namespace FindHikingFellow.Core.Models.Tour
{
/// <summary>
/// Used to visualize tours (by destinations) with their name and image in Index page and Destinations/All
/// </summary>
    public class TourViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
