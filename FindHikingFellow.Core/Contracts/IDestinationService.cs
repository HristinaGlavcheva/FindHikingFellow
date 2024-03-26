using FindHikingFellow.Core.Models;
using FindHikingFellow.Core.Models.Destination;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FindHikingFellow.Core.Contracts
{
    public interface IDestinationService
    {
        Task<IEnumerable<ListDestinationsViewModel>> ListDestinationsAsync();

        Task<AllDestinationsViewModel> GetAllDestinationsAsync();

        Task<IEnumerable<AddDestinationFormModel>> GetMostPopularDestinationsAsync();

        Task<bool> DestinationExistsByIdAsync(int destinationId);

        Task<bool> DestinationExistsByNameAsync(string destinationName);

        Task<int> AddDestinationAsync(AddDestinationFormModel input);
    }
}
