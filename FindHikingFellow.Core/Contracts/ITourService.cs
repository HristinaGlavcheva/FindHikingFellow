using FindHikingFellow.Core.Enumerations;
using FindHikingFellow.Core.Models.Tour;

namespace FindHikingFellow.Core.Contracts
{
    public interface ITourService
    {
        Task<IEnumerable<TourViewModel>> GetSoonestUpcomingToursAsync();

        Task<int> CreateTourAsync(CreateTourFormModel input, string organiserId);

        Task<bool> TourWithSameNameExists(string name);

        Task<TourQueryServiceModel> AllAsync(
            string? destination = null,
            string? searchTerm = null,
            TourSorting sorting = TourSorting.Newest,
            int currentPage = 1, 
            int toursPerPage = 3);

        Task<IEnumerable<string>> AllDestinationsNamesAsync();

        Task<IEnumerable<TourServiceModel>> AllToursByOrganiserId(string userId);

        Task<IEnumerable<TourServiceModel>> AllToursByUserId(string userId);
    }
}
