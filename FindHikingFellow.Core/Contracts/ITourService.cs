using FindHikingFellow.Core.Models;

namespace FindHikingFellow.Core.Contracts
{
    public interface ITourService
    {
        Task<IEnumerable<TourServiceModel>> GetMostResentToursAsync();
    }
}
