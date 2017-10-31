namespace FDMC
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<CatDbContext>(opt => opt.UseSqlServer($"Server=.;Database=CatDb;Integrated Security=True;"));
        }

        private static void CatPage(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.Headers.Add("Content-Type", "text/html");

                await context.Response.WriteAsync($@"<h1>Name</h1>
                    <img src=""cat.jpg"" width=""300""/>
                    <p> Age: number </p>
                    <p> Breed: type </p> ");
            });
        }

        private static void AddCatPage(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.Headers.Add("Content-Type", "text/html");
                var a = context.Response;
                await context.Response.WriteAsync($@"<h1>Add Cat</h1>

                <form method=""post"">
                    Name: <input type= ""text"" name = ""name"" />
                    <br />
                    Age: <input type= ""number"" name = ""age"" />
                    <br />
                    Breed: <input type= ""text"" name = ""breed"" />
                    <br />
                    ImageUrl: <input type= ""url"" name = ""imageUrl"" />
                    <br />
                    <input type= ""submit"" value = ""Add Cat"" />
                </form>");
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //CatDbContext db = new CatDbContext();
            //db.Database.EnsureCreated();
            //db.Database.EnsureDeleted();

            app.Map("/cat/add", AddCatPage);

            app.Map("/cat", CatPage);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(@"<h1>Fluffy Duffy Munchkin Cats</h1>");
            });
        }
    }
}