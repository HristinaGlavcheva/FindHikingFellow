using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static FindHikingFellow.Infrastructure.Constants.CustomClaims;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder.HasData(SeedClaims());
        }

        private IdentityUserClaim<string>[] SeedClaims()
        {
            ICollection<IdentityUserClaim<string>> claims = new HashSet<IdentityUserClaim<string>>();

            IdentityUserClaim<string> userFullNameClaim = null!;

            userFullNameClaim = new IdentityUserClaim<string>()
            {
                Id = 1,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Organiser First",
                UserId = "9baea4e0-3afa-4b47-80d3-cfcd4b43e79b"
            };

            claims.Add(userFullNameClaim);

            userFullNameClaim = new IdentityUserClaim<string>()
            {
                Id = 2,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Admin First",
                UserId = "7d23c6db-4f9c-44c2-8a7d-c4ef9030122d"
            };

            claims.Add(userFullNameClaim);

            userFullNameClaim = new IdentityUserClaim<string>()
            {
                Id = 3,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Participant First",
                UserId = "aec4bd2b-913c-425a-936f-8d2bd83c1164"
            };

            claims.Add(userFullNameClaim);

            userFullNameClaim = new IdentityUserClaim<string>()
            {
                Id = 4,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Participant Second",
                UserId = "480fd4fe-3c32-4626-8ea9-ada588d0d24f"
            };

            claims.Add(userFullNameClaim);

            return claims.ToArray();
        }
    }
}
