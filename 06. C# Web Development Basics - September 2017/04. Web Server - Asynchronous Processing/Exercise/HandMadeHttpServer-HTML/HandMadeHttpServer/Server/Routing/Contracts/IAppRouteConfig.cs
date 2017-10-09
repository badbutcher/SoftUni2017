namespace HandMadeHttpServer.Server.Routing.Contracts
{
    using System.Collections.Generic;
    using HandMadeHttpServer.Server.Enums;
    using HandMadeHttpServer.Server.Handlers;

    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes { get; }

        void AddRoute(string route, RequestHandler httpHandler);
    }
}