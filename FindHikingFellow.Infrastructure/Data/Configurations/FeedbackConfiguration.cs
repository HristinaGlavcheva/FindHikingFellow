using FindHikingFellow.Infrastructure.Data.Models;
using FindHikingFellow.Infrastructure.Data.Models.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class FeedbackConfiguration : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.HasData(SeedFeedbacks());
        }

        private FeedBack[] SeedFeedbacks()
        {
            ICollection<FeedBack> feedBacks = new HashSet<FeedBack>()
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
                };

            return feedBacks.ToArray();
        }
    }
}
