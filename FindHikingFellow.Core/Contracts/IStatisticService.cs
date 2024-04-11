using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Statistics;
using System.Runtime.InteropServices;

namespace FindHikingFellow.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}

