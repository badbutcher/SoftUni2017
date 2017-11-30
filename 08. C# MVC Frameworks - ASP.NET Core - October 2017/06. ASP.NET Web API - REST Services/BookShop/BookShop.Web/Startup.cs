namespace BookShop.Web
{
    using AutoMapper;
    using BookShop.Data;
    using BookShop.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookShopDbContext>();

            services.AddDomainServices();

            services.AddAutoMapper();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            ////app.UseMvc(routes =>
            ////{
            ////    routes.MapRoute(
            ////        name: "default",
            ////        template: "{controller=Home}/{action=Index}/{id?}");

            ////    routes.MapRoute(
            ////        name: "api",
            ////        template: "api/{controller=Home}/{action=Index}/{id?}");
            ////});

            ////app.UseMvcWithDefaultRoute();
        }
    }
}