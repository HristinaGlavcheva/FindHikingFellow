using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Tour;
using Microsoft.AspNetCore.Authorization;
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

            await tourService.CreateTourAsync(input, User.Id());
            
            // TODO: Redirect to tour details page
            return this.Redirect("/");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]AllToursQueryModel query)
        {
            var queryResult = await tourService.AllAsync(
                query.Destination,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllToursQueryModel.ToursPerPage);

            var tourDestinations = await tourService.AllDestinationsNamesAsync();

            query.Destinations = tourDestinations;
            query.TotalTours = queryResult.TotalToursCount;
            query.Tours = queryResult.Tours;

            return View(query);
        }

        public IActionResult Archive()
        {
            return View();
        }
    }
}
