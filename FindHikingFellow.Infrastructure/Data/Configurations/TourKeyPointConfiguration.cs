using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class TourKeyPointConfiguration : IEntityTypeConfiguration<TourKeyPoint>
    {
        public void Configure(EntityTypeBuilder<TourKeyPoint> builder)
        {
            builder.HasKey(tkp => new {tkp.TourId, tkp.KeyPointId});
        }
    }
}
