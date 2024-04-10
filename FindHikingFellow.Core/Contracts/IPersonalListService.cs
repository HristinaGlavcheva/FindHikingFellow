using FindHikingFellow.Core.Models.PersonalList;

namespace FindHikingFellow.Core.Contracts
{
    public interface IPersonalListService
    {
        Task<IEnumerable<ListNameViewModel>> ViewListsNamesAsync();

        Task<bool> ListExistsByNameAsync(string listName);

        Task<int> AddListAsync(AddListFormModel input);

        Task<bool> ListExistsByIdAsync(int listId);

        Task AddToListAsync(int listId, int tourId, string userId);

        Task<bool> IsTheTourAddedToThisListAsync(int listId, int tourId, string userId);

        Task<IEnumerable<MyListViewModel>> GetMyListsAsync(string userId);

        Task RemoveFromListAsync(int tourId, int listId);
    }
}
