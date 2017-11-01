namespace FDMC
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CatDbContext>(opt => opt.UseSqlServer($"Server=.;Database=CatDb;Integrated Security=True;"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UserDatabaseMigration();

            app.UseStaticFiles();

            app.UseHttpMethodOverride();

            app.MapWhen(ctx => ctx.Request.Path.Value == "/" && ctx.Request.Method == "GET",
                home =>
                {
                    home.Run(async (context) =>
                    {
                        await context.Response.WriteAsync($"<h1>{env.ApplicationName}</h1>");

                        var db = context.RequestServices.GetService<CatDbContext>();

                        using (db)
                        {
                            var catData = db.Cats
                           .Select(c => new
                           {
                               c.Id,
                               c.Name
                           })
                           .ToList();

                            await context.Response.WriteAsync("<ul>");

                            foreach (var cat in catData)
                            {
                                await context.Response.WriteAsync($@"<li><a href=""/cat/{cat.Id}"">{cat.Name}</a></li>");
                            }

                            await context.Response.WriteAsync("</ul>");

                            await context.Response.WriteAsync(@"
                            <form action=""/cat/add"">
                                <input type = ""submit"" value=""Add Cat"" />
                            </form>");
                        }
                    });
                });

            app.MapWhen(req => req.Request.Path.Value == "/cat/add",
                catAdd =>
                {
                    catAdd.Run(async (context) =>
                   {
                       if (context.Request.Method == "GET")
                       {
                           context.Response.StatusCode = 302;
                           context.Response.Headers.Add("Location", "/cats-add-form.html");
                       }
                       else if (context.Request.Method == "POST")
                       {
                           var formData = context.Request.Form;

                           var age = 0;
                           int.TryParse(formData["Age"], out age);

                           Cat cat = new Cat
                           {
                               Name = formData["Name"],
                               Age = age,
                               Breed = formData["Breed"],
                               ImageUrl = formData["ImageUrl"],
                           };

                           try
                           {
                               if (string.IsNullOrWhiteSpace(cat.Name) ||
                               string.IsNullOrWhiteSpace(cat.Breed) ||
                               string.IsNullOrWhiteSpace(cat.ImageUrl))
                               {
                                   throw new InvalidOperationException("Wrong cat data");
                               }

                               var db = context.RequestServices.GetService<CatDbContext>();

                               using (db)
                               {
                                   db.Add(cat);

                                   await db.SaveChangesAsync();

                                   context.Response.StatusCode = 302;
                                   context.Response.Headers.Add("Location", "/");
                               }
                           }
                           catch (Exception)
                           {
                               await context.Response.WriteAsync("<h2>Invalid cat data!</h2>");
                               await context.Response.WriteAsync(@"<a href=""/cat/add"">Back to the form</a>");
                           }
                       }
                   });
                });

            app.MapWhen(ctx => ctx.Request.Path.Value.StartsWith("/cat") && ctx.Request.Method == "GET",
                catDetail =>
                {
                    catDetail.Run(async (context) =>
                    {
                        var urlParts = context.Request.Path.Value.Split('/', StringSplitOptions.RemoveEmptyEntries);
                        if (urlParts.Length < 2)
                        {
                            context.Response.Redirect("/");
                        }
                        else
                        {
                            var catId = 0;
                            int.TryParse(urlParts[1], out catId);
                            if (catId == 0)
                            {
                                context.Response.Redirect("/");
                                return;
                            }

                            var db = context.RequestServices.GetService<CatDbContext>();

                            using (db)
                            {
                                var cat = await db.Cats.FindAsync(catId);
                                if (cat == null)
                                {
                                    context.Response.Redirect("/");
                                    return;
                                }

                                await context.Response.WriteAsync($@"<h1>{cat.Name}</h1>
                                        <img src=""{cat.ImageUrl}"" width=""300""/>
                                        <p>Age: {cat.Age} </p>
                                        <p>Breed: {cat.Breed} </p>");
                            }
                        }
                    });
                });

            app.Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("404");
            });
        }
    }
}