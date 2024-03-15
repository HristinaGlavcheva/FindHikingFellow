using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class TourPersonalListConfiguration : IEntityTypeConfiguration<TourPersonalList>
    {
        public void Configure(EntityTypeBuilder<TourPersonalList> builder)
        {
            builder.HasKey(tpl => new {tpl.TourId, tpl.PersonalListId});
        }
    }
}
