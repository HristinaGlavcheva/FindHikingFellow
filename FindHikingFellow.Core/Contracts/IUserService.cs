using FindHikingFellow.Core.Models.Admin;

namespace FindHikingFellow.Core.Contracts
{
    public interface IUserService
    {
        Task<string> UserFullNameAsync(string userId);

        Task<IEnumerable<UserServiceModel>> AllAsync();
    }
}
