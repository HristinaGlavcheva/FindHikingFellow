using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.PersonalList;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FindHikingFellow.Controllers
{
    public class PersonalListController : BaseController
    {
        private readonly IPersonalListService personalListService;
        private readonly ITourService tourService;

        public PersonalListController(IPersonalListService _personalListService, ITourService _tourService)
        {
            personalListService = _personalListService;
            tourService = _tourService;
        }

        [HttpGet]
        public IActionResult AddNewList()
        {
            var model = new AddListFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewList(AddListFormModel input)
        {
            if (await personalListService.ListExistsByNameAsync(input.Name) == true)
            {
                ModelState.AddModelError(nameof(input.Name), "A liist with this name already exists");
            }

            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            await personalListService.AddListAsync(input);

            return RedirectToAction("AddToList", "Tour");
        }

        public async Task<IActionResult> MyLists()
        {
            var model = await personalListService.GetMyListsAsync(User.Id());

            return View(model);
        }

        public async Task<IActionResult> RemoveFromList(int tourId, int listId)
        {
            if (!await tourService.ExistsAsync(tourId))
            {
                return BadRequest();
            }

            if (await personalListService.ListExistsByIdAsync(listId) == false)
            {
                return BadRequest();
            }

            if (await personalListService.IsTheTourAddedToThisListAsync(listId, tourId, User.Id()))
            {
                await personalListService.RemoveFromListAsync(tourId, listId);
            }

            return RedirectToAction(nameof(MyLists));
        }
    }
}

