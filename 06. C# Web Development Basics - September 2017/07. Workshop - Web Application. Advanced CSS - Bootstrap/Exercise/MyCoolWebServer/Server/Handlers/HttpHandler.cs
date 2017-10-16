namespace MyCoolWebServer.Server.Handlers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Common;
    using Contracts;
    using Http.Contracts;
    using Http.Response;
    using Routing.Contracts;
    using Server.Http;

    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig routeConfig)
        {
            CoreValidator.ThrowIfNull(routeConfig, nameof(routeConfig));

            this.serverRouteConfig = routeConfig;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            try
            {
                // Check if user is authenticated
                //string[] anonymousPathsCake = new[] { "/login", "/register" };
                string[] anonymousPathsGames = new[] { "/account/login", "/account/register" };

                if (!anonymousPathsGames.Contains(context.Request.Path) &&
                    (context.Request.Session == null || !context.Request.Session.Contains(SessionStore.CurrentUserKey)))
                {
                    return new RedirectResponse(anonymousPathsGames.First());
                }

                var requestMethod = context.Request.Method;
                string requestPath = context.Request.Path;
                var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

                foreach (var registeredRoute in registeredRoutes)
                {
                    string routePattern = registeredRoute.Key;
                    var routingContext = registeredRoute.Value;

                    Regex routeRegex = new Regex(routePattern);
                    Match match = routeRegex.Match(requestPath);

                    if (!match.Success)
                    {
                        continue;
                    }

                    var parameters = routingContext.Parameters;

                    foreach (var parameter in parameters)
                    {
                        string parameterValue = match.Groups[parameter].Value;
                        context.Request.AddUrlParameter(parameter, parameterValue);
                    }

                    return routingContext.Handler.Handle(context);
                }
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }

            return new NotFoundResponse();
        }
    }
}