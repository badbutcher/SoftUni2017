namespace FDMC.Middleware
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class HtmlContentTypeMiddleware
    {
        private readonly RequestDelegate next;

        public HtmlContentTypeMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Content-Type", "text/html");
            return this.next(context);
        }
    }
}