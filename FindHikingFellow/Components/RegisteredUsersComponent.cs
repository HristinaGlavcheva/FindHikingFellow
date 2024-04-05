using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Components;
using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow.Components
{
    public class RegisteredUsersComponent : ViewComponent
    {
        private readonly IRegisteredUsersService usersService;

        public RegisteredUsersComponent(IRegisteredUsersService _usersService)
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
