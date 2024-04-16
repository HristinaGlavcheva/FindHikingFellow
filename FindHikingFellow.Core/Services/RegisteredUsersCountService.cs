using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;

namespace FindHikingFellow.Core.Services
{
    public class RegisteredUsersCountService : IRegisteredUsersCountService
    {
        private readonly IRepository userRepository;

        public RegisteredUsersCountService(IRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public int RegisteredUsersCount()
        {
            return userRepository.AllAsNoTracking<ApplicationUser>().Count();
        }
    }
}
