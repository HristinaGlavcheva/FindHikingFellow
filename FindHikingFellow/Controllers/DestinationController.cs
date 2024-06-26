﻿using Microsoft.AspNetCore.Mvc;
using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Destination;

namespace FindHikingFellow.Controllers
{
    public class DestinationController : BaseController
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

        [HttpGet]
        public IActionResult Add()
        {
            var model = new DestinationFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DestinationFormModel input)
        {
            if (await destinationService.DestinationExistsByNameAsync(input.Name) == true)
            {
                ModelState.AddModelError(nameof(input.Name), "This destination already exists");
            }

            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            await destinationService.AddDestinationAsync(input);

            return RedirectToAction("Create", "Tour");
        }
    }
}
