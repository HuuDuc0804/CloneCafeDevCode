using CafeDevCode.Database;
using CafeDevCode.Database.Entities;
using CafeDevCode.Database.Seeders;
using CafeDevCode.Logic.Commands.Request;
using CafeDevCode.Logic.MappingProfile;
using CafeDevCode.Utils.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CafeDevCode.Website
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null)
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Service Collection Extension
            builder.Services.AddCookiesAuthenticate(builder.Configuration);
            builder.Services.AddSqlServerDatabase<AppDatabase>(builder.Configuration
                .GetConnectionString("Database"));
            builder.Services.AddIdentityConfig<User, IdentityRole, AppDatabase>();

            // Add AutoMapper & MediatR
            builder.Services.AddMediatR(typeof(Login).Assembly);
            builder.Services.AddAutoMapper(typeof(AuthorMappingProfile).Assembly);

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //Create Scope
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var database = scope.ServiceProvider.GetRequiredService<AppDatabase>();

                await database.Database.MigrateAsync();
                await ApppSeeder.InitializeAsync(database, userManager, roleManager);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}