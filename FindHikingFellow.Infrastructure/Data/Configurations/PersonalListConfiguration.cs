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
                new PersonalList { Name = "Completed"},
                new PersonalList { Name = "Favourites"},
                new PersonalList { Name = "Wish to perform"},
                new PersonalList { Name = "Planned"}
            };

            return lists.ToArray();
        }
    }
}
