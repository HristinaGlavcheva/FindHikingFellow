using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Destination;
using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow.Areas.Admin.Controllers
{
    public class DestinationController : AdminBaseController
    {
        private readonly IDestinationService destinationService;

        public DestinationController(IDestinationService _destinationService)
        {
            destinationService = _destinationService;
        }

        public async Task<IActionResult> All()
        {
            var model = await destinationService.GetAllDestinationsAsync();

            return View(model);
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await destinationService.GetDestinationFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DestinationFormModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            await destinationService.EditDestinationAsync(input, id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await destinationService.DestinationToBeDeletedById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DestinationFormModel input, int id)
        {
            if (await destinationService.DestinationHasTours(id))
            {
                return BadRequest();
            }

            await destinationService.DeleteDestinationByIdAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}
