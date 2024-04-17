using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Tour;
using FindHikingFellow.Core.Services;
using FindHikingFellow.Infrastructure.Data;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;
using FindHikingFellow.Infrastructure.Data.Models.Enumerations;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FindMyHikingFellow.Tests
{
    [TestFixture]
    public class TourServiceUnitTests
    {
        private ApplicationDbContext dbContext;

        private IEnumerable<Tour> tours;
        private IEnumerable<Destination> destinations;
        private List<TourParticipant> tourParticipants;

        //private Mock<ITourService> mockTourService;

        //private Mock<IRepository> mockTourRepository;
        //private Mock<IRepository> mockKeyPointRepository;
        //private Mock<IRepository> mockTourParticipantRepository;

        private TourService tourService;
        private IRepository tourRepository;
        private IRepository keyPointRepository;
        private IRepository tourParticipantRepository;


        //Tours
        private Tour VihrenPeak;
        private Tour MalyovitsaPeak;
        private Tour HotnitsaWaterfall;
        private Tour SevenRilaLakes;

        //Destinations
        private Destination Pirin;
        private Destination Rila;
        private Destination BalkanMauntains;
        private Destination Rodopi;

        [SetUp]
        public async Task SetUp()
        {
            //mockTourService = new Mock<ITourService>();
            //mockTourRepository = new Mock<IRepository>();
            //mockKeyPointRepository = new Mock<IRepository>();
            //mockTourParticipantRepository = new Mock<IRepository>();


            //Tours
            VihrenPeak = new Tour
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
                OrganiserId = "Organiser_Tour_1_Id"
            };

            MalyovitsaPeak = new Tour
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
                OrganiserId = "Organiser_Tour_2_Id",
            };

            HotnitsaWaterfall = new Tour
            {
                Id = 3003,
                Name = "Hotnitsa Waterfall",
                DestinationId = 3001,
                ImageUrl = "https://www.gptravel.bg/img/uploads/tours/5633/40475_orig.webp",
                Difficulty = Difficulty.Easy,
                ActivityType = ActivityType.Walking,
                RouteType = RouteType.OutAndBack,
                Description = "Amaizing waterfall, there is an ecotrail but I don't know its condition.",
                Duration = "It depends of the ecotrail condition",
                MeetingPoint = "Hotnitsa Village",
                MeetingTime = new DateTime(2024, 03, 20, 9, 0, 0),
                OrganiserId = "Organiser_Tour_3003_Id",
            };

            SevenRilaLakes = new Tour
            {
                Id = 3,
                Name = "Seven Rila Lakes",
                DestinationId = 2,
                ImageUrl = "https://luckybansko.bg/wp-content/uploads/2019/03/rila1.jpg",
                Difficulty = Difficulty.Medium,
                ActivityType = ActivityType.Hiking,
                RouteType = RouteType.Loop,
                Length = 10,
                ElevationGain = 533,
                Description = "One of the most popular hikes in Rila mountain. We will enjoy great view during entire hike. It is very crowded on weekends so I suppose a Wednesday to be ok to visit.",
                Duration = "4.5 hours with lunch and pictures stops",
                MeetingPoint = "Pionerska Hut",
                MeetingTime = new DateTime(2024, 09, 25, 8, 30, 0),
                OrganiserId = "Organiser_Tour_4_Id",
            };

            tours = new List<Tour>()
            {
                VihrenPeak, MalyovitsaPeak, SevenRilaLakes, HotnitsaWaterfall
            };

            //Destinations
            Pirin = new Destination
            {
                Id = 1,
                Name = "Pirin",
                ImageUrl = "https://webnews.bg/uploads/images/84/8784/228784/768x432.jpg?_=1460885734"
            };

            Rila = new Destination
            {
                Id = 2,
                Name = "Rila",
                ImageUrl = "https://vedri.bg/media/fufl535h/national-park-rila-bulgaria.jpg"
            };

            BalkanMauntains = new Destination
            {
                Id = 3,
                Name = "Balkan Mountains",
                ImageUrl = "https://trud.bg/public/images/articles/2020-11/mountain-landscape-beautiful-hd-wallpaper-1024x640_1509577115668281610_original.jpg"
            };

            Rodopi = new Destination
            {
                Id = 4,
                Name = "Rodopi",
                ImageUrl = "https://bulgariawalking.com/wp-content/uploads/2016/10/rhodopes-and-rila-2.jpg"
            };

            destinations = new List<Destination>()
            {
                Pirin, Rila, BalkanMauntains, Rodopi
            };

            //TourParticipants
            tourParticipants = new List<TourParticipant>();

            var tourParticipant = new TourParticipant
            {
                ParticipantId = "Organiser_Tour_4_Id",
                TourId = 1
            };

            tourParticipants.Add(tourParticipant);

            //Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "FindHikingFellowInMemoryDb")
            .Options;

            dbContext = new ApplicationDbContext(options);

            await dbContext.AddRangeAsync(tours);
            await dbContext.AddRangeAsync(destinations);
            await dbContext.SaveChangesAsync();

            tourRepository = new Repository(dbContext);
            keyPointRepository = new Repository(dbContext);
            tourParticipantRepository = new Repository(dbContext);
            tourService = new TourService(tourRepository, keyPointRepository, tourParticipantRepository);
        }

        [Test]
        public async Task TourExistsAsync_ShouldReturnCorrectResult()
        {
            // Arrange
            int tourId = 1;
            int fakeTourId = -5;

            // Act
            var resultTrue = await tourService.ExistsAsync(tourId);
            var resultFalse = await tourService.ExistsAsync(fakeTourId);

            // Assert
            Assert.That(resultTrue, Is.EqualTo(true));
            Assert.That(resultFalse, Is.EqualTo(false));
        }

        [Test]
        public async Task TourWithSameNameExists_ShoudReturnCorrectResult()
        {
            //Act
            var resultTrue = await tourService.TourWithSameNameExists("Vihren Peak");
            var resultFalse = await tourService.TourWithSameNameExists("Koncheto");

            //Assert
            Assert.That(resultTrue, Is.EqualTo(true));
            Assert.That(resultFalse, Is.EqualTo(false));
        }

        [Test]
        public async Task IsOrganisedBy_ShouldReturnCorrectResult()
        {
            //Act
            var resultTrue = await tourService.IsOrganisedBy(1, "Organiser_Tour_1_Id");
            var resultFalse = await tourService.IsOrganisedBy(1, "Organiser_Tour_2_Id");

            //Assert
            Assert.That(resultTrue, Is.EqualTo(true));
            Assert.That(resultFalse, Is.EqualTo(false));
        }

        [Test]
        public async Task IsTourFinished_ShouldReturnCorrectResult()
        {
            //Act
            var resultTrue = await tourService.IsTourFinished(3003);
            var resultFalse = await tourService.IsTourFinished(1);

            //Assert
            Assert.That(resultTrue, Is.EqualTo(true));
            Assert.That(resultFalse, Is.EqualTo(false));
        }

        [Test]
        public async Task Test_AllDestinationsNamesAsync_ReturnsTheCorrectResult()
        {
            // Act
            var result = await tourService.AllDestinationsNamesAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(4));
            Assert.That(result.First(), Is.EqualTo("Pirin"));
            Assert.That(result.Skip(1).First(), Is.EqualTo("Rila"));
            Assert.That(result.Skip(2).First(), Is.EqualTo("Balkan Mountains"));
            Assert.That(actual: result.Skip(3).First(), Is.EqualTo(expected: "Rodopi"));
        }
    }
}
