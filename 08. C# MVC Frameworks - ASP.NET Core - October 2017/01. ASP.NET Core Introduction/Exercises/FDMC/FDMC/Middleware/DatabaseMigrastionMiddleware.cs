namespace FDMC.Middleware
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class DatabaseMigrastionMiddleware
    {
        private readonly RequestDelegate next;

        public DatabaseMigrastionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.RequestServices.GetRequiredService<CatDbContext>().Database.Migrate();
            return this.next(context);
        }
    }
}