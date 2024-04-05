using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Infrastructure.Data;
using FindHikingFellow.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;

namespace FindHikingFellow.Core.Services
{
    public class RegisteredUsersService : IRegisteredUsersService
    {
        private readonly IRepository userRepository;

        public RegisteredUsersService(IRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public int RegisteredUsersCount()
        {
            return userRepository.AllAsNoTracking<IdentityUser>().Count();
        }
    }
}
