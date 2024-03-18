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

            tour = new Tour
            {
                Id = 2,
                Name = "Malyovitsa Peak",
                DestinationId = 2,
                Difficulty = Difficulty.Challenging,
                ActivityType = ActivityType.Hiking,
                RouteType = RouteType.OutAndBack,
                Length = 15.9,
                ElevationGain = 1017,
                Description = "Very scenic and beautiful hiking. Dramatic cliffs, lakes and stunning views from the summit. Big part of the trail is very rocky so use stable hiking shoes. It’s physically demanding but an amaizing one. There is lots of water so no need to bring extra.",
                Duration = "About 7 hours inlucding breaks for pictures and a lunch break",
                MeetingPoint = "Malyovitsa hotel",
                MeetingTime = new DateTime(2024, 07, 25, 7, 0, 0),
                OrganiserId = "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                Participants = new HashSet<TourParticipant>() { new TourParticipant { TourId = 2, ParticipantId = "aec4bd2b-913c-425a-936f-8d2bd83c1164" } },
                FeedBacks = new FeedBack[]
                {
                      new FeedBack
                      {
                            Id = 1,
                            Rate = 5,
                            ActivityType = ActivityType.Hiking,
                            CreatedOn = new DateTime(2023, 04, 02),
                            AuthorId = "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                            TourId = 2,
                            Review = "Amazing trail. It had snowed the day before and it looked like a winter wonderland. Towards the end, follow the other mountaineers and don’t follow the all trails route. That being said, I didn’t have any snow spikes and the descent was SCARY. Managed to pull through. I even lost my phone on the trial, luckily I had my burner phone with my Bulgarian sim, which is why this journey starts halfway through. Anyway, it is so worth it. Get ready for an adventure almost 9,000 feet up in the Bulgarian mountains",
                      },
                       new FeedBack
                       {
                            Id = 2,
                            Rate = 5,
                            ActivityType = ActivityType.Backpacking,
                            CreatedOn = new DateTime(2022, 07, 14),
                            AuthorId = "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                            TourId = 2
                       }
                },
                KeyPoints = new KeyPoint[]
                {
                    new KeyPoint
                    {
                        Id = 1, 
                        Name = "Malyovitsa hut"
                    },
                    new KeyPoint
                    {

                    }
                }
            };

            tours.Add(tour);

            return tours.ToArray();
        }
    }
}
