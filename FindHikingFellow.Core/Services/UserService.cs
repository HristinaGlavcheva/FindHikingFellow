using Microsoft.EntityFrameworkCore;
using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Admin;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;

namespace FindHikingFellow.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository userRepository;

        public UserService(IRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await userRepository
                .AllAsNoTracking<ApplicationUser>()
                .Select(u => new UserServiceModel
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.PhoneNumber
                })
                .ToListAsync();
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;
            var user = await userRepository.GetByIdAsync<ApplicationUser>(userId);

            if(user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
