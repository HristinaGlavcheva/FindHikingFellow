using FindHikingFellow.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow.Controllers
{
    public class DestinationController : BaseController
    {
        private readonly IDestinationService destinationService;

        public DestinationController(IDestinationService _destinationService)
        {
            destinationService = _destinationService;
        }

        public async Task<IActionResult> All( )
        {
            var model = await destinationService.GetAllDestinationsAsync();

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

    }
}
