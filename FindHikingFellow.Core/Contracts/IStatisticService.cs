using FindHikingFellow.Core.Models.Statistics;

namespace FindHikingFellow.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}

