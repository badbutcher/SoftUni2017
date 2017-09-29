namespace WebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using WebServer.Server.Enums;
    using WebServer.Server.Handlers;
    using WebServer.Server.Routing.Contracts;

    public class ServerRouteConfig : IServerRouteConfig
    {
        public ServerRouteConfig(IAppRouteConfig appRouteConfig)
        {
            this.Routes = new Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>>();

            //TODO:

            this.InitializeServerConfig(appRouteConfig);
        }

        private void InitializeServerConfig(IAppRouteConfig appRouteConfig)
        {
            foreach (KeyValuePair<HttpRequestMethod, Dictionary<string, RequestHandler>> kvp in appRouteConfig.Routes)
            {
                foreach (KeyValuePair<string, RequestHandler> requestHandler in kvp.Value)
                {
                    List<string> args = new List<string>();

                    string parsedRegex = this.ParseRoute(requestHandler.Key, args);

                    IRoutingContext routingContext = new RoutingContext(/*requestHandler.Value, args*/);

                    this.Routes[kvp.Key].Add(parsedRegex, routingContext);
                }
            }
        }

        private string ParseRoute(string key, List<string> args)
        {
            throw new NotImplementedException();
        }

        public Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; private set; }
    }
}