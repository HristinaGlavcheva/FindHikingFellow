using FindHikingFellow.Core.Models.Admin;

namespace FindHikingFellow.Core.Contracts
{
    public interface IJoinedService
    {
        Task<IEnumerable<JoinedServiceModel>> AllAsync();
    }
}
