using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Feedback;
using FindHikingFellow.Core.Models.PersonalList;
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
        private readonly IFeedbackService feedbackService;
        private readonly IPersonalListService personalListService;

        public TourController(
            ITourService _tourService,
            IDestinationService _destinationService,
            IFeatureService _featureService,
            IFeedbackService _feedbackService,
            IPersonalListService _personalListService)
        {
            tourService = _tourService;
            destinationService = _destinationService;
            featureService = _featureService;
            feedbackService = _feedbackService;
            personalListService = _personalListService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new TourFormModel()
            {
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
                return this.View(input);
            }

            var newTourId = await tourService.CreateTourAsync(input, User.Id());

            return RedirectToAction(nameof(Details), new { id = newTourId });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllToursQueryModel query)
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

        [HttpPost]
        public async Task<IActionResult> Details(FeedbackFormModel input, int id)
        {
            if (!await tourService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var newFeedback = await feedbackService.CreateFeedbackAsync(input, id, User.Id());

            return RedirectToAction(nameof(Details));
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
            if (await tourService.ExistsAsync(id) == false)
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
            if (await tourService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await tourService.IsOrganisedBy(id, User.Id()) == false)
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

        public async Task<IActionResult> Join(int id)
        {
            if (await tourService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await tourService.IsOrganisedBy(id, User.Id()))
            {
                return Unauthorized();
            }

            if (await tourService.IsJoinedByUserWithIdAsync(id, User.Id()) == false)
            {
                await tourService.JoinAsync(id, User.Id());
            }

            return RedirectToAction(nameof(MyTours));
        }

        public async Task<IActionResult> Leave(int id)
        {
            if (await tourService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await tourService.IsOrganisedBy(id, User.Id()))
            {
                return Unauthorized();
            }

            if(await tourService.IsJoinedByUserWithIdAsync(id, User.Id()) == true)
            {
                await tourService.LeaveAsync(id, User.Id());
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> CreateListForUser()
        {
            var model = new AddToListFormModel()
            {
                Lists = await personalListService.ViewListsNamesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateListForUser(AddToListFormModel input, int id)
        {

            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}
