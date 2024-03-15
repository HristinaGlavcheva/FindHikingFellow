using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class TourFeatureConfiguration : IEntityTypeConfiguration<TourFeature>
    {
        public void Configure(EntityTypeBuilder<TourFeature> builder)
        {
            builder.HasKey(tf => new {tf.TourId, tf.FeatureId});
        }
    }
}
