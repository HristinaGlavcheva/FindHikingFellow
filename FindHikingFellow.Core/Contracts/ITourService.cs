using FindHikingFellow.Core.Enumerations;
using FindHikingFellow.Core.Models.Tour;
using FindHikingFellow.Core.Models.TourKeyPoint;

namespace FindHikingFellow.Core.Contracts
{
    public interface ITourService
    {
        Task<IEnumerable<TourServiceModel>> GetSoonestUpcomingToursAsync();

        Task<int> CreateTourAsync(TourFormModel input, string organiserId);

        Task EditTourAsync(TourFormModel input, int tourId);

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

        Task<bool> ExistsAsync(int id);

        Task<bool> IsOrganisedBy(int tourId, string userId);

        Task<TourDetailsServiceModel> TourDetailsByIdAsync(int id);

        Task<IEnumerable<TourServiceModel>> GetToursByDestinationAsync(string destination);

        Task<TourFormModel?> GetTourFormModelByIdAsync(int id);

        Task<IEnumerable<TourKeyPointModel>> ListKeyPointsAsync(int id);

        Task<TourToBeDeletedServiceModel> TourToBeDeletedById(int id);

        Task DeleteTourByIdAsync(int tourId);

        Task<bool> IsJoinedByUserWithIdAsync(int tourId, string userId);

        Task<bool> IsTourFinished(int id);

        Task JoinAsync(int id, string userId);

        Task LeaveAsync(int id, string userId);

        Task ApproveTourAsync(int tourId);

        Task<IEnumerable<TourServiceModel>> GetUnApprovedAsync();
    }
}
