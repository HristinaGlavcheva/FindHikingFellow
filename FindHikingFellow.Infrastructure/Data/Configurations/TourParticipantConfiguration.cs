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
            builder.HasData(SeedTourParticipants());
        }

        private TourParticipant[] SeedTourParticipants()
        {
            ICollection<TourParticipant> tourParticipants = new HashSet<TourParticipant>()
            {
                {
                    new TourParticipant
                    {
                        TourId = 2, ParticipantId = "aec4bd2b-913c-425a-936f-8d2bd83c1164"
                    }
                }
            };

            return tourParticipants.ToArray();
        }
    }
}
