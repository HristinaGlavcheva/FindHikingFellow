using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow.Controllers
{
    public class TourController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
