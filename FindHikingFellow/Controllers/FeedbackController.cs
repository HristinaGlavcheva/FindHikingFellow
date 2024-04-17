using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Feedback;
using FindHikingFellow.Core.Extensions;

namespace FindHikingFellow.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly ITourService tourService;
        private readonly IFeedbackService feedbackService;

        public FeedbackController(ITourService _tourService, IFeedbackService _feedbackService)
        {
            tourService = _tourService;
            feedbackService = _feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new FeedbackFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeedbackFormModel input, int id)
        {
            if (!await tourService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(input);
            }

            await feedbackService.CreateFeedbackAsync(input, id, User.Id());

            var tour = await tourService.TourDetailsByIdAsync(id);

            return RedirectToAction("Details", "Tour", new { id = id, information = tour.GetInformation() });
        }
    }
}
