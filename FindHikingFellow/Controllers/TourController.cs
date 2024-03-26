using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Tour;
using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FindHikingFellow.Controllers
{
    public class TourController : BaseController
    {
        private readonly ITourService tourService;
        private readonly IDestinationService destinationService;
        private readonly IFeatureService featureService;

        public TourController(
            ITourService _tourService,
            IDestinationService _destinationService,
            IFeatureService _featureService)
        {
            tourService = _tourService;
            destinationService = _destinationService;
            featureService = _featureService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateTourFormModel()
            {
                MeetingTime = DateTime.UtcNow,
                Destinations = await destinationService.ListDestinationsAsync(),
                Features = await featureService.ListFeaturesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTourFormModel input)
        {
            if (await tourService.TourWithSameNameExists(input.Name) == true)
            {
                ModelState.AddModelError(nameof(input.Name), "Tour with that name already exists");
            }

            if (await destinationService.DestinationExistsByIdAsync(input.DestinationId) == false)
            {
                ModelState.AddModelError(nameof(input.DestinationId), "This destination does not exist");
            }

            if (!ModelState.IsValid)
            {
                input.Destinations = await destinationService.ListDestinationsAsync();
                input.Features = await featureService.ListFeaturesAsync();
                return this.View(input);
            }
            //return this.Json(input);

            await tourService.CreateTourAsync(input, User.Id());
            
            // TODO: Redirect to tour details page
            return this.Redirect("/");
        }

        public IActionResult Archive()
        {
            return View();
        }
    }
}
