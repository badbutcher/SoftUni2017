namespace WebServer.Server.Routing
{
    using System.Collections.Generic;
    using WebServer.Server.Handlers;
    using WebServer.Server.Routing.Contracts;

    public class RoutingContext : IRoutingContext
    {
        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler RequestHandler { get; private set; }
    }
}