using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.PersonalList;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FindHikingFellow.Core.Services
{
    public class PersonalListService : IPersonalListService
    {
        private readonly IRepository personalListRepository;
        private readonly IRepository tourPersonalListRepository;
        private readonly IRepository tourRepository;

        public PersonalListService(
            IRepository _personalListRepository,
            IRepository _tourPersonalListRepository,
            IRepository _tourRepository)
        {
            personalListRepository = _personalListRepository;
            tourPersonalListRepository = _tourPersonalListRepository;
            tourRepository = _tourRepository;
        }

        public async Task<int> AddListAsync(AddListFormModel input)
        {
            var newList = new PersonalList()
            {
                Name = input.Name
            };

            await personalListRepository.AddAsync(newList);
            await personalListRepository.SaveChangesAsync();

            return newList.Id;
        }

        public async Task<bool> ListExistsByNameAsync(string listName)
        {
            return await personalListRepository
                .AllAsNoTracking<PersonalList>()
                .AnyAsync(l => l.Name == listName);
        }

        public async Task<IEnumerable<ListViewModel>> ViewListsNamesAsync()
        {
            var lists = await personalListRepository
                .AllAsNoTracking<PersonalList>()
                .Select(l => new ListViewModel
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToListAsync();

            return lists;
        }

        public async Task<bool> ListExistsByIdAsync(int listId)
        {
            return await personalListRepository
                .AllAsNoTracking<PersonalList>()
                .AnyAsync(l => l.Id == listId);
        }

        public async Task<bool> IsTheTourAddedToThisListAsync(int listId, int tourId, string userId)
        {
            return await tourPersonalListRepository
                .AllAsNoTracking<TourPersonalList>()
                .AnyAsync(tpl => tpl.TourId == tourId
                        && tpl.PersonalList.Id == listId
                        && tpl.OwnerId == userId);
        }

        public async Task AddToListAsync(int listId, int tourId, string userId)
        {
            var tour = await tourRepository
                     .AllAsNoTracking<Tour>()
                     .FirstAsync(t => t.Id == tourId);

            var list = await personalListRepository
                .AllAsNoTracking<PersonalList>()
                .Where(pl => pl.Id == listId)
                .FirstOrDefaultAsync();

            if (await IsTheTourAddedToThisListAsync(listId, tourId, userId) == false && !tour.IsDeleted)
            {
                var tourPersonaList = new TourPersonalList
                {
                    OwnerId = userId,
                    TourId = tourId,
                    PersonalListId = list.Id
                };

                await tourPersonalListRepository.AddAsync(tourPersonaList);
                await tourPersonalListRepository.SaveChangesAsync();
            }
        }
    }
}