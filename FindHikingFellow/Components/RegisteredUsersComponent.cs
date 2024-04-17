using Microsoft.AspNetCore.Mvc;
using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Components;

namespace FindHikingFellow.Components
{
    public class RegisteredUsersComponent : ViewComponent
    {
        private readonly IRegisteredUsersCountService usersService;

        public RegisteredUsersComponent(IRegisteredUsersCountService _usersService)
        {
            usersService = _usersService;
        }

        public IViewComponentResult Invoke(string title)
        {
            var usersCount = usersService.RegisteredUsersCount();

            var model = new RegisteredUsersViewModel
            {
                Title = title,
                UsersCount = usersCount
            };

            return View(model);
        }
    }
}
