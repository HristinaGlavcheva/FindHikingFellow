using FindHikingFellow.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow.Areas.Admin.Controllers
{
    public class TourController : AdminBaseController
    {
        private readonly ITourService tourService;

        public TourController(ITourService _tourService)
        {
            tourService = _tourService;
        }

        [HttpGet]
        public async Task<IActionResult> Approve()
        {
            var model = await tourService.GetUnApprovedAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int tourId)
        {
            await tourService.ApproveTourAsync(tourId);

            return RedirectToAction(nameof(Approve));
        }
    }
}
