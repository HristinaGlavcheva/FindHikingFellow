using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models;
using FindHikingFellow.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FindHikingFellow.Controllers
{
    public class HomeController : Controller
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

        public async Task<IActionResult> Index()
        {
            var destinationServiceModels = await destinationService.GetMostPopularDestinationsAsync();
            var tourServiceModels = await tourService.GetMostResentToursAsync();

            var indexViewModel = new IndexViewModel
            {
                Destinations = destinationServiceModels.Select(d => new DestinationViewModel
                {
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                })
                .ToList(),
                Tours = tourServiceModels.Select(t => new TourViewModel
                {
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                })
                .ToList(),
            };

            return this.View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
