using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models;
using FindHikingFellow.Core.Models.PersonalList;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHikingFellow.Core.Services
{
    public class PersonalListService : IPersonalListService
    {
        private readonly IRepository personalListRepository;
        private readonly IRepository tourPersonalListRepository;

        public PersonalListService(
            IRepository _personalListRepository, 
            IRepository _tourPersonalListRepository)
        {
            personalListRepository = _personalListRepository;
            tourPersonalListRepository = _tourPersonalListRepository;
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

        //public async Task<bool> TourIsAlreadyInTheList(string name, int id)
        //{
        //    await tourPersonalListRepository
        //        .AllAsNoTracking<TourPersonalList>()
        //        .AnyAsync(tpl => tpl.PersonalList.Name == name && tpl.PersonalList.)
        //}

        public async Task<IEnumerable<ListViewModel>> ViewListsAsync()
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

        //public async Task<IEnumerable<ListDestinationsViewModel>> ListDestinationsAsync()
        //{
        //    var destinations = destinationRepository
        //        .AllAsNoTracking<Destination>()
        //        .Select(d => new ListDestinationsViewModel
        //        {
        //            Id = d.Id,
        //            Name = d.Name,
        //        })
        //        .ToListAsync();

        //    return await destinations;
        //}
    }
}
