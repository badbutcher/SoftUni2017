namespace HandMadeHttpServer.Server.Routing
{
    using System.Collections.Generic;
    using HandMadeHttpServer.Server.Handlers;
    using HandMadeHttpServer.Server.Routing.Contracts;

    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(RequestHandler requestHandler, IEnumerable<string> parameters)
        {
            this.RequestHandler = requestHandler;
            this.Parameters = parameters;
        }

        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler RequestHandler { get; private set; }
    }
}