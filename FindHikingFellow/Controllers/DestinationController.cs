using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow.Controllers
{
    public class DestinationController : BaseController
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
