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
                new Feature { Name = "Hut" },
                new Feature { Name = "Forest" },
                new Feature { Name = "Lake" },
                new Feature { Name = "River" },
                new Feature { Name = "Waterfall"},
                new Feature { Name = "Cave"},
                new Feature { Name = "Dog friendly"},
                new Feature { Name = "Kid friendly"},
                new Feature { Name = "Camping possibility"},
                new Feature { Name = "Rock climbing"},
                new Feature { Name = "Via ferrata"},
                new Feature { Name = "Ecotrail"},
                new Feature { Name = "Beach"},
                new Feature { Name = "Views"},
                new Feature { Name = "Historic site"}
            };

            return features.ToArray();
        }
    }
}
