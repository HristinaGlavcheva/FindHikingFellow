using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Destination;
using FindHikingFellow.Core.Models.Home;
using FindHikingFellow.Core.Models.Tour;
using FindHikingFellow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            var tourServiceModels = await tourService.GetMostResentToursAsync();

            var indexViewModel = new IndexViewModel
            {
                Destinations = new AllDestinationsViewModel
                {
                    AllDestinations = destinationViewModels
                    .Select(d => new AddDestinationFormModel
                    {
                        Name = d.Name,
                        ImageUrl = d.ImageUrl,
                    })
                .ToList()
                },
                Tours = tourServiceModels.Select(t => new TourViewModel
                {
                    Name = t.Name,
                    ImageUrl = t.ImageUrl,
                })
                .ToList(),
            };

            return this.View(indexViewModel);
    }

    [AllowAnonymous]
    public IActionResult Privacy()
    {
        return View();
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
