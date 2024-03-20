using FindHikingFellow.Core.Models;

namespace FindHikingFellow.Core.Contracts
{
    public interface IDestinationService
    {
        Task<IEnumerable<ListDestinationsViewModel>> ListDestinationsNamesAsync();

        Task<IEnumerable<DestinationServiceModel>> GetMostPopularDestinationsAsync();
    }
}
