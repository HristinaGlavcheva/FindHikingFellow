using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class TourPersonalListConfiguration : IEntityTypeConfiguration<TourPersonalList>
    {
        public void Configure(EntityTypeBuilder<TourPersonalList> builder)
        {
            builder.HasKey(tpl => new { tpl.TourId, tpl.PersonalListId });
            //builder.HasData(SeedTourPersonalLists());
        }

        //private TourPersonalList[] SeedTourPersonalLists()
        //{
        //    ICollection<TourPersonalList> tourPersonalLists = new HashSet<TourPersonalList>()
        //    {
        //        new TourPersonalList
        //        {
        //            PersonalListId = 2,
        //            TourId = 1,
        //        },
        //         new TourPersonalList
        //        {
        //            PersonalListId = 4,
        //            TourId = 2
        //        }
        //    };

        //    return tourPersonalLists.ToArray();
        //}
    }
}
