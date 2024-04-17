using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationDbContext(builder.Configuration);
            builder.Services.AddApplicationIdentity(builder.Configuration);

            builder.Services.AddControllersWithViews(options =>
            options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>());

            builder.Services.AddApplicationServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Tour Details",
                    pattern: "/Tour/Details/{id}/{information}",
                    defaults: new { Controller = "Tour", Action = "Details" }
                    );
                endpoints.MapControllerRoute(
                   name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

            await app.CreateAdminRoleAsync();

            await app.RunAsync();
        }
    }
}