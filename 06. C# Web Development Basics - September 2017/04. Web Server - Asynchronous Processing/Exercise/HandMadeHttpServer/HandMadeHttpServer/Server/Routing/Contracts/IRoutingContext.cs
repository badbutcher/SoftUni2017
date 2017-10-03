namespace HandMadeHttpServer.Server.Routing.Contracts
{
    using System.Collections.Generic;
    using HandMadeHttpServer.Server.Handlers;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler RequestHandler { get; }
    }
}