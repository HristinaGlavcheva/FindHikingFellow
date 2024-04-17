using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Services;
using FindHikingFellow.Infrastructure.Data;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<IDestinationService, DestinationService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IRegisteredUsersCountService, RegisteredUsersCountService>();
            services.AddScoped<IPersonalListService, PersonalListService>();
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJoinedService, JoinedService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = config.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                    options.Password.RequireNonAlphanumeric = config.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                    options.Password.RequireDigit = config.GetValue<bool>("Identity:Password:RequireDigit");
                    options.Password.RequireLowercase = config.GetValue<bool>("Identity:Password:RequireLowercase");
                    options.Password.RequireUppercase = config.GetValue<bool>("Identity:Password:RequireUppercase");
                    options.Password.RequiredLength = config.GetValue<int>("Identity:Password:RequiredLength");
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
