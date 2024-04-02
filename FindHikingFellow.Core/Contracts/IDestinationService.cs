using FindHikingFellow.Core.Models;
using FindHikingFellow.Core.Models.Destination;
using FindHikingFellow.Core.Models.Tour;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FindHikingFellow.Core.Contracts
{
    public interface IDestinationService
    {
        Task<IEnumerable<ListDestinationsViewModel>> ListDestinationsAsync();

        Task<IEnumerable<DestinationViewModel>> GetAllDestinationsAsync();

        Task<IEnumerable<DestinationViewModel>> GetMostPopularDestinationsAsync();

        Task<bool> DestinationExistsByIdAsync(int destinationId);

        Task<bool> DestinationExistsByNameAsync(string destinationName);

        Task<int> AddDestinationAsync(AddDestinationFormModel input);
    }
}
