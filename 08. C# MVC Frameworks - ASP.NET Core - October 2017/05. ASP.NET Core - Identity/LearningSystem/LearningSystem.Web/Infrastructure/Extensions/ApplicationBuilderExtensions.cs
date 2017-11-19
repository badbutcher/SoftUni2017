namespace LearningSystem.Web.Infrastructure.Extensions
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<LearningSystemDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    Type type = typeof(GlocalConstants);
                    var flags = BindingFlags.Static | BindingFlags.Public;
                    var allConstants = type.GetFields(flags);

                    foreach (var item in allConstants)
                    {
                        var roleName = (string)typeof(GlocalConstants).GetField(item.Name).GetValue(null);

                        var roleExists = await roleManager.RoleExistsAsync(roleName);

                        if (!roleExists)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = roleName
                            });
                        }
                    }

                    var adminName = GlocalConstants.Administrator;

                    var adminUser = await userManager.FindByNameAsync(adminName);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            Email = "admin@admin.com",
                            UserName = "admin@admin.com",
                            Name = "admin"
                        };

                        await userManager.CreateAsync(adminUser, "admin12");

                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }
                }).Wait();
            }

            return app;
        }
    }
}