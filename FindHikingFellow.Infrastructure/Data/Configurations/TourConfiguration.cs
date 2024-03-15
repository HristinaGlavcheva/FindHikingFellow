using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FindHikingFellow.Infrastructure.Data.Models.Enumerations;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasData(SeedTour());
        }

        private Tour[] SeedTour()
        {
            ICollection<Tour> tours = new HashSet<Tour>();

            Tour tour = null!;

            tour = new Tour
            {
                Id = 1,
                Name = "Vihren Peak",
                DestinationId = 1,
                Difficulty = Difficulty.Challenging,
                ActivityType = ActivityType.Hiking,
                RouteType = RouteType.OutAndBack,
                Length = 8.5,
                ElevationGain = 931,
                Description = "Let's enjoy together this trail near Bansko, Blagoevgrad. Generally considered a challenging route, this is a very popular area for hiking.",
                Duration = "About 6 hours inlucding breaks for pictures and a lunch break",
                MeetingPoint = "Vihren hut",
                MeetingTime = new DateTime(2024, 08, 13, 7, 0, 0),
                OrganiserId = "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                Participants = new HashSet<TourParticipant>() { }

            };

            tours.Add(tour);

            return tours.ToArray();
        }
    }
}
