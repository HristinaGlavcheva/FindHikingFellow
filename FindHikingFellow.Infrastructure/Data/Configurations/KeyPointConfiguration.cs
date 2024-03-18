using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class KeyPointConfiguration : IEntityTypeConfiguration<KeyPoint>
    {
        public void Configure(EntityTypeBuilder<KeyPoint> builder)
        {
            builder.HasData(SeedKeyPoints());
        }

        private KeyPoint[] SeedKeyPoints()
        {
            ICollection<KeyPoint> keyPoints = new HashSet<KeyPoint>
            {
                new KeyPoint { Id = 1, Name = "Malyovitsa Hut" },
                new KeyPoint { Id = 2, Name = "Vihren Hut" },
                new KeyPoint { Id = 3, Name = "Popovo Lake" },
                new KeyPoint { Id = 4, Name = "Kazanite" },
                new KeyPoint { Id = 5, Name = "Koncheto Shelter"},
                new KeyPoint { Id = 6, Name = "Koncheto"},
                new KeyPoint { Id = 7, Name = "Vidimsko Praskalo Waterfall"},
                new KeyPoint { Id = 8, Name = "Yastrebets lift station"},
                new KeyPoint { Id = 9, Name = "Yontchevo Lake"},
                new KeyPoint { Id = 10, Name = "Elenino Lake"}
            };

            return keyPoints.ToArray();
        }
    }
}
