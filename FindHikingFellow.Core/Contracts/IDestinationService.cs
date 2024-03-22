﻿using FindHikingFellow.Core.Models;
using FindHikingFellow.Core.Models.Destination;

namespace FindHikingFellow.Core.Contracts
{
    public interface IDestinationService
    {
        Task<IEnumerable<ListDestinationsViewModel>> ListDestinationsAsync();

        Task<AllDestinationsViewModel> GetAllDestinationsAsync();

        Task<IEnumerable<AddDestinationFormModel>> GetMostPopularDestinationsAsync();

        Task<int> AddDestinationAsync(AddDestinationFormModel input);
    }
}
