namespace FDMC
{
    using FDMC.Middleware;
    using Microsoft.AspNetCore.Builder;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UserDatabaseMigration(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DatabaseMigrastionMiddleware>();
        }

        public static IApplicationBuilder UseHtmlContentType(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HtmlContentTypeMiddleware>();
        }
    }
}