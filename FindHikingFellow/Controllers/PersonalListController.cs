using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.PersonalList;
using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow.Controllers
{
    public class PersonalListController : BaseController
    {
        private readonly IPersonalListService personalListService;

        public PersonalListController(IPersonalListService _personalListService)
        {
            personalListService = _personalListService;
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
    }
}

