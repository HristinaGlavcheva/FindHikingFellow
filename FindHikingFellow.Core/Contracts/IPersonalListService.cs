using FindHikingFellow.Core.Models.PersonalList;

namespace FindHikingFellow.Core.Contracts
{
    public interface IPersonalListService
    {
        Task<IEnumerable<ListViewModel>> ViewListsAsync();

        //Task<bool> TourIsAlreadyInTheList(string name);

        Task<bool> ListExistsByNameAsync(string listName);

        Task<int> AddListAsync(AddListFormModel input);
    }
}
