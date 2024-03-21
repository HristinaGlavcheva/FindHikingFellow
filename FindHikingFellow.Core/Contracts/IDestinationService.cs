using FindHikingFellow.Core.Models;
using FindHikingFellow.Core.Models.Destination;

namespace FindHikingFellow.Core.Contracts
{
    public interface IDestinationService
    {
        Task<IEnumerable<ListDestinationsViewModel>> ListDestinationsAsync();

        Task<IEnumerable<DestinationServiceModel>> GetMostPopularDestinationsAsync();
    }
}
