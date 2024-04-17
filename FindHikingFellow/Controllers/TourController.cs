using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Extensions;
using FindHikingFellow.Core.Models.Feedback;
using FindHikingFellow.Core.Models.PersonalList;
using FindHikingFellow.Core.Models.Tour;
using FindHikingFellow.Infrastructure.Data.Models;

namespace FindHikingFellow.Controllers
{
    public class TourController : BaseController
    {
        private readonly ITourService tourService;
        private readonly IDestinationService destinationService;
        private readonly IFeedbackService feedbackService;
        private readonly IPersonalListService personalListService;

        public TourController(
            ITourService _tourService,
            IDestinationService _destinationService,
            IFeedbackService _feedbackService,
            IPersonalListService _personalListService)
        {
            tourService = _tourService;
            destinationService = _destinationService;
            feedbackService = _feedbackService;
            personalListService = _personalListService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new TourFormModel()
            {
                Destinations = await destinationService.ListDestinationsAsync(),
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
                return View(input);
            }

            var newTourId = await tourService.CreateTourAsync(input, User.Id());

            return RedirectToAction(nameof(All));
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
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await tourService.ExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await tourService.TourDetailsByIdAsync(id);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }

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

            if (await tourService.IsOrganisedBy(id, User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var model = await tourService.GetTourFormModelByIdAsync(id);

            model.Destinations = await destinationService.ListDestinationsAsync();
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

            if (await tourService.IsOrganisedBy(id, User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (await tourService.IsTourFinished(id) && User.IsAdmin() == false)
            {
                return BadRequest();
            }

            if (await destinationService.DestinationExistsByIdAsync(input.DestinationId) == false)
            {
                ModelState.AddModelError(nameof(input.DestinationId), "This destination does not exist");
            }

            if (!ModelState.IsValid)
            {
                input.Destinations = await destinationService.ListDestinationsAsync();
                return View(input);
            }

            await tourService.EditTourAsync(input, id);

            return RedirectToAction(nameof(Details), new { id, information = input.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, string information)
        {
            if (await tourService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await tourService.IsOrganisedBy(id, User.Id()) == false && !User.IsAdmin())
            {
                return Unauthorized();
            }

            var model = await tourService.TourToBeDeletedById(id);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TourServiceModel model)
        {
            if (await tourService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await tourService.IsOrganisedBy(model.Id, User.Id()) == false && !User.IsAdmin())
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

            if (await tourService.IsOrganisedBy(id, User.Id()) && !User.IsAdmin())
            {
                return Unauthorized();
            }

            if (await tourService.IsJoinedByUserWithIdAsync(id, User.Id()))
            {
                ModelState.AddModelError(nameof(id), "You have already joined this tour");
            }

            if (await tourService.IsTourFinished(id))
            {
                ModelState.AddModelError(nameof(id), "You cannot join finished tour");
            }

            await tourService.JoinAsync(id, User.Id());

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
        public async Task<IActionResult> AddToList()
        {
            var model = new AddToListFormModel()
            {
                Lists = await personalListService.ViewListsNamesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToList(AddToListFormModel input, int id)
        {
            if (!await tourService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (await personalListService.ListExistsByIdAsync(input.ListId) == false)
            {
                return BadRequest();
            }

            if (await personalListService.IsTheTourAddedToThisListAsync(input.ListId, id, User.Id()))
            {
                ModelState.AddModelError(nameof(input.ListId), "You have already added the tour to this list");
            }

            if (!ModelState.IsValid)
            {
                input.Lists = await personalListService.ViewListsNamesAsync();
                return this.View(input);
            }

            await personalListService.AddToListAsync(input.ListId, id, User.Id());

            return RedirectToAction("MyLists", "PersonalList");
        }
    }
}
