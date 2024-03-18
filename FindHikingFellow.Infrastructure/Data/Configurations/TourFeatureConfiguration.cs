using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class TourFeatureConfiguration : IEntityTypeConfiguration<TourFeature>
    {
        public void Configure(EntityTypeBuilder<TourFeature> builder)
        {
            builder.HasKey(tf => new { tf.TourId, tf.FeatureId });
            builder.HasData(SeedTourFeatures());
        }

        private TourFeature[] SeedTourFeatures()
        {
            ICollection<TourFeature> tourFeatures = new HashSet<TourFeature>()
               {
                    new TourFeature
                    {
                        TourId= 2,
                        FeatureId= 1,
                    },
                    new TourFeature
                    {
                        TourId= 2,
                        FeatureId= 3,
                    },
                    new TourFeature
                    {
                        TourId= 2,
                        FeatureId= 14
                    }
               };

            return tourFeatures.ToArray();
        }
    }
}
