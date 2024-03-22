﻿using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Destination;
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

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddDestinationFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDestinationFormModel input)
        {
            await destinationService.AddDestinationAsync(input);

            return RedirectToAction("Create", "Tour");
        }
    }
}
