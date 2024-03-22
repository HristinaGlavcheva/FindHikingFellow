using FindHikingFellow.Core.Models.Tour;

namespace FindHikingFellow.Core.Contracts
{
    public interface ITourService
    {
        Task<IEnumerable<TourServiceModel>> GetMostResentToursAsync();

        Task<int> CreateTourAsync(CreateTourFormModel input, string organiserId);
    }
}
