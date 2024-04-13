using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Destination;
using FindHikingFellow.Core.Models.Home;
using FindHikingFellow.Core.Models.Tour;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDestinationService destinationService;
        private readonly ITourService tourService;

        public HomeController(
            ILogger<HomeController> logger,
            IDestinationService _destinationsService,
            ITourService _tourService)
        {
            _logger = logger;
            destinationService = _destinationsService;
            tourService = _tourService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var destinationViewModels = await destinationService.GetMostPopularDestinationsAsync();
            var tourViewModels = await tourService.GetSoonestUpcomingToursAsync();

            var indexViewModel = new IndexViewModel
            {
                Destinations = destinationViewModels
                    .Select(d => new DestinationViewModel
                    {
                        Name = d.Name,
                        ImageUrl = d.ImageUrl
                    })
                .ToList(),
                Tours = tourViewModels.Select(t => new TourServiceModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                    Description = t.Description
                })
                .ToList()
            };

            return View(indexViewModel);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 400)
            {
                return View("Error400");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
