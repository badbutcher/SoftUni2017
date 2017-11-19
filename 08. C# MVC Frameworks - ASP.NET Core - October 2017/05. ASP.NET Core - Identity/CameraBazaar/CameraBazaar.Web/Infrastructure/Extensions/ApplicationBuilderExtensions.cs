namespace CameraBazaar.Web.Infrastructure.Extensions
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;
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
                serviceScope.ServiceProvider.GetService<CameraBazaarDbContext>().Database.Migrate();

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

                    var adminName = GlocalConstants.AdminRole;

                    var adminUser = await userManager.FindByNameAsync(adminName);

                    if (adminUser == null)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            adminUser = new User
                            {
                                Email = $"Admin@Admin{i}.com",
                                UserName = $"Admin{i}"
                            };

                            await userManager.CreateAsync(adminUser, $"Admin{i}");

                            await userManager.AddToRoleAsync(adminUser, adminName);
                        }
                    }
                }).Wait();
            }

            return app;
        }
    }
}