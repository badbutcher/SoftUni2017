namespace CameraBazaar.Web.Infrastructure.Filters
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            using (var writer = new StreamWriter("logs.txt", true))
            {
                var dateTime = DateTime.UtcNow;
                var ipAddress = context.HttpContext.Connection.RemoteIpAddress;
                var userName = context.HttpContext.User?.Identity?.Name ?? "Anonymous";
                var controller = context.Controller.GetType().Name;
                var action = context.RouteData.Values["action"];

                var logMesseage = $"{dateTime} – {ipAddress} – {userName} – {controller}.{action}";

                if (context.Exception != null)
                {
                    var exceptionType = context.Exception.GetType().Name;
                    var excpetionMessage = context.Exception.Message;

                    logMesseage = $"[!] {logMesseage} - {exceptionType} – {excpetionMessage}";
                }

                writer.WriteLine(logMesseage);
            }
        }
    }
}