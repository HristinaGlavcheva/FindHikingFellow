using FindHikingFellow.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Core.Models.Tour
{
    public class AllToursQueryModel
    {
        public const int ToursPerPage = 3;

        public string Destination { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public TourSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalTours { get; set; }

        public IEnumerable<string> Destinations { get; set; } = null!;

        public IEnumerable<TourServiceModel> Tours { get; set; } = new HashSet<TourServiceModel>();
    }
}
