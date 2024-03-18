using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class PersonalListConfiguration : IEntityTypeConfiguration<PersonalList>
    {
        public void Configure(EntityTypeBuilder<PersonalList> builder)
        {
            builder.HasData(SeedPersonalLists());
        }

        private PersonalList[] SeedPersonalLists()
        {
            ICollection<PersonalList> lists = new HashSet<PersonalList>()
            {
                new PersonalList { Id = 1, Name = "Completed"},
                new PersonalList { Id = 2, Name = "Favourites"},
                new PersonalList { Id = 3, Name = "Wish to perform"},
                new PersonalList { Id = 4, Name = "Planned"}
            };

            return lists.ToArray();
        }
    }
}
