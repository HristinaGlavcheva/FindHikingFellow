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
            builder
                .Property(t => t.IsDeleted)
                .HasDefaultValue(false);

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
                ImageUrl = "https://www.datocms-assets.com/55179/1647278287-screen-shot-2019-07-22-at-7-13-00-am.png",
                ActivityType = ActivityType.Hiking,
                RouteType = RouteType.OutAndBack,
                Length = 8.5,
                ElevationGain = 931,
                Description = "Let's enjoy together this trail near Bansko, Blagoevgrad. Generally considered a challenging route, this is a very popular area for hiking.",
                Duration = "About 6 hours inlucding breaks for pictures and a lunch break",
                MeetingPoint = "Vihren hut",
                MeetingTime = new DateTime(2024, 08, 13, 7, 0, 0),
                OrganiserId = "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b"
            };

            tours.Add(tour);

            tour = new Tour
            {
                Id = 2,
                Name = "Malyovitsa Peak",
                DestinationId = 2,
                ImageUrl = "https://novavarna.net/wp-content/uploads/2020/06/rila_maliovica-1280x720.jpg",
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
            };

            tours.Add(tour);

            //tour = new Tour
            //{
            //    Id = 3003,
            //    Name = "Hotnitsa Waterfall",
            //    DestinationId = 3001,
            //    ImageUrl = "https://www.gptravel.bg/img/uploads/tours/5633/40475_orig.webp",
            //    Difficulty = Difficulty.Easy,
            //    ActivityType = ActivityType.Walking,
            //    RouteType = RouteType.OutAndBack,
            //    Description = "Amaizing waterfall, there is an ecotrail but I don't know its condition.",
            //    Duration = "It depends of the ecotrail condition",
            //    MeetingPoint = "Hotnitsa Village",
            //    MeetingTime = new DateTime(2024, 05, 20, 9, 0, 0),
            //    OrganiserId = "aac8a25a-876d-46d7-a2ba-d82658bbc066",
            //};

            //tours.Add(tour);

            //tour = new Tour
            //{
            //    Id = 3,
            //    Name = "Seven Rila Lakes",
            //    DestinationId = 2,
            //    ImageUrl = "https://luckybansko.bg/wp-content/uploads/2019/03/rila1.jpg",
            //    Difficulty = Difficulty.Medium,
            //    ActivityType = ActivityType.Hiking,
            //    RouteType = RouteType.Loop,
            //    Length = 10,
            //    ElevationGain = 533,
            //    Description = "One of the most popular hikes in Rila mountain. We will enjoy great view during entire hike. It is very crowded on weekends so I suppose a Wednesday to be ok to visit.",
            //    Duration = "4.5 hours with lunch and pictures stops",
            //    MeetingPoint = "Pionerska Hut",
            //    MeetingTime = new DateTime(2024, 09, 25, 8, 30, 0),
            //    OrganiserId = "c5ea995b-0f28-450e-a11c-06e6a93798c3",
            //};

            //tours.Add(tour);

            return tours.ToArray();
        }
    }
}
