using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedUsers());
        }

        private IdentityUser[] SeedUsers()
        {
            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

            ApplicationUser user = null!;

            var hasher = new PasswordHasher<ApplicationUser>();

            user = new ApplicationUser()
            {
                Id = "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                UserName = "organiser@gmail.com",
                NormalizedUserName = "ORGANISER@GMAIL.COM",
                Email = "organiser@gmail.com",
                NormalizedEmail = "ORGANISER@GMAIL.COM",
                FirstName = "Organiser",
                LastName = "First"
            };

            user.PasswordHash = hasher.HashPassword(user, "organiser1");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "7d23c6db-4f9c-44c2-8a7d-c4ef9030122d",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                FirstName = "Admin",
                LastName = "First"
            };

            user.PasswordHash = hasher.HashPassword(user, "admin1");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                UserName = "participant1@gmail.com",
                NormalizedUserName = "PARTICIPANT1@GMAIL.COM",
                Email = "participant1@gmail.com",
                NormalizedEmail = "PARTICIPANT1@GMAIL.COM",
                FirstName = "Participant",
                LastName = "First"
            };

            user.PasswordHash = hasher.HashPassword(user, "participant1");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "480fd4fe-3c32-4626-8ea9-ada588d0d24f",
                UserName = "participant2@gmail.com",
                NormalizedUserName = "PARTICIPANT2@GMAIL.COM",
                Email = "participant2@gmail.com",
                NormalizedEmail = "PARTICIPANT2@GMAIL.COM",
                FirstName = "Participant",
                LastName = "Second"
            };

            user.PasswordHash = hasher.HashPassword(user, "participant2");
            users.Add(user);

            return users.ToArray();
        }
    }
}
