using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class TourParticipantConfiguration : IEntityTypeConfiguration<TourParticipant>

    {
        public void Configure(EntityTypeBuilder<TourParticipant> builder)
        {
            builder.HasKey(tp => new {tp.TourId, tp.ParticipantId});
        }
    }
}
