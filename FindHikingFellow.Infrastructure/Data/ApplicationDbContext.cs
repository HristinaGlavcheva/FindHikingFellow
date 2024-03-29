using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FindHikingFellow.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; } = null!;

        public DbSet<Destination> Destinations { get; set; } = null!;

        public DbSet<Feature> Features { get; set; } = null!;

        public DbSet<FeedBack> FeedBacks { get; set; } = null!;

        public DbSet<Image> Images { get; set; } = null!;

        public DbSet<KeyPoint> KeyPoints { get; set; } = null!;

        public DbSet<PersonalList> PersonalLists { get; set; } = null!;

        public DbSet<TourFeature> TourFeatures { get; set; } = null!;

        public DbSet<TourKeyPoint> TourKeyPoints { get; set; } = null!;

        public DbSet<TourParticipant> TourParticipants { get; set; } = null!;

        public DbSet<TourPersonalList> TourPersonalLists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly =
                Assembly.GetAssembly(typeof(ApplicationDbContext)) ?? Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);

            // Disable cascade delete
            var entityTypes = builder.Model.GetEntityTypes().ToList();

            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
