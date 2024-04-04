using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Tour;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var model = new TourFormModel()
            {
                MeetingTime = DateTime.UtcNow,
                Destinations = await destinationService.ListDestinationsAsync(),
                Features = await featureService.ListFeaturesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TourFormModel input)
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

            var newTourId = await tourService.CreateTourAsync(input, User.Id());
            
            return RedirectToAction(nameof(Details), new {id = newTourId});
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

        public async Task<IActionResult> MyTours()
        {
            var userId = User.Id();

            var organised = await tourService.AllToursByOrganiserId(userId);
            var joined = await tourService.AllToursByUserId(userId);

            var model = new MyToursServiceModel
            {
                Joined = joined,
                Organised = organised
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await tourService.ExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await tourService.TourDetailsByIdAsync(id);
            
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ToursByDestination(string destination)
        {
            var model = await tourService.GetToursByDestinationAsync(destination);

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> SoonestUpcoming()
        {
            var model = await tourService.GetSoonestUpcomingToursAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(await tourService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await tourService.IsOrganisedBy(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var model = await tourService.GetTourFormModelByIdAsync(id);

            model.Destinations = await destinationService.ListDestinationsAsync();
            model.Features = await featureService.ListFeaturesAsync();
            model.KeyPoints = await tourService.ListKeyPointsAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TourFormModel input)
        {
            if (await tourService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await tourService.IsOrganisedBy(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await destinationService.DestinationExistsByIdAsync(input.DestinationId) == false)
            {
                ModelState.AddModelError(nameof(input.DestinationId), "This destination does not exist");
            }

            if (!ModelState.IsValid)
            {
                input.Destinations = await destinationService.ListDestinationsAsync();
                input.Features = await featureService.ListFeaturesAsync();
                return View(input);
            }

            await tourService.EditTourAsync(input, id);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(await tourService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if(await tourService.IsOrganisedBy(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var model = await tourService.TourToBeDeletedById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TourServiceModel model)
        {
            if (await tourService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await tourService.IsOrganisedBy(model.Id, User.Id()) == false)
            {
                return Unauthorized();
            }

            await tourService.DeleteTourByIdAsync(model.Id);

            return RedirectToAction(nameof(MyTours));
        }
    }
}
