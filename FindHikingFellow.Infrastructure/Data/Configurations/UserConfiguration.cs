using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(SeedUsers());
        }

        private IdentityUser[] SeedUsers()
        {
            ICollection<IdentityUser> users = new HashSet<IdentityUser>();

            IdentityUser user = null!;

            var hasher = new PasswordHasher<IdentityUser>();

            user = new IdentityUser()
            {
                Id = "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b",
                UserName = "Organiser",
                NormalizedUserName = "ORGANISER",
                Email = "organiser@gmail.com",
                NormalizedEmail = "ORGANISER@GMAIL.COM"
            };

            user.PasswordHash = hasher.HashPassword(user, "organiser123");
            users.Add(user);

            user = new IdentityUser()
            {
                Id = "aec4bd2b-913c-425a-936f-8d2bd83c1164",
                UserName = "Participant",
                NormalizedUserName = "PARTICIPANT",
                Email = "participant@gmail.com",
                NormalizedEmail = "PARTICIPANT@GMAIL.COM"
            };

            user.PasswordHash = hasher.HashPassword(user, "participant123");
            users.Add(user);

            return users.ToArray();
        }
    }
}
