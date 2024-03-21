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

        public TourController(ITourService _tourService, IDestinationService _destinationService)
        {
            tourService = _tourService;
            destinationService = _destinationService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateTourFormModel()
            {
                Destinations = await destinationService.ListDestinationsAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTourFormModel input)
        {
            if (!ModelState.IsValid)
            {
                input.Destinations = await destinationService.ListDestinationsAsync();
                return this.View();
            }

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
