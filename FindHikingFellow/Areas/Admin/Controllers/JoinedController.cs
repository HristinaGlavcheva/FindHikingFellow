using FindHikingFellow.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow.Areas.Admin.Controllers
{
    public class JoinedController : AdminBaseController
    {
        private readonly IJoinedService joinedService;

        public JoinedController(IJoinedService _joinedService)
        {
            joinedService = _joinedService;
        }

        public async Task<IActionResult> All()
        {
            var model = await joinedService.AllAsync();
            
            return View(model);
        }
    }
}
