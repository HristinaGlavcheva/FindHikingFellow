using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasData(SeedFeatures());
        }

        private Feature[] SeedFeatures()
        {
            ICollection<Feature> features = new HashSet<Feature>
            {
                new Feature { Id = 1, Name = "Hut" },
                new Feature { Id = 2, Name = "Forest" },
                new Feature { Id = 3, Name = "Lake" },
                new Feature { Id = 4, Name = "River" },
                new Feature { Id = 5, Name = "Waterfall"},
                new Feature { Id = 6, Name = "Cave"},
                new Feature { Id = 7, Name = "Dog friendly"},
                new Feature { Id = 8, Name = "Kid friendly"},
                new Feature { Id = 9, Name = "Camping possibility"},
                new Feature { Id = 10, Name = "Rock climbing"},
                new Feature { Id = 11, Name = "Via ferrata"},
                new Feature { Id = 12, Name = "Ecotrail"},
                new Feature { Id = 13, Name = "Beach"},
                new Feature { Id = 14, Name = "Views"},
                new Feature { Id = 15, Name = "Historic site"}
            };

            return features.ToArray();
        }
    }
}
