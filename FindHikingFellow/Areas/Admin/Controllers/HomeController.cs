using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }

        public async Task<IActionResult> ForFeview()
        {
            return View();
        }
    }
}
