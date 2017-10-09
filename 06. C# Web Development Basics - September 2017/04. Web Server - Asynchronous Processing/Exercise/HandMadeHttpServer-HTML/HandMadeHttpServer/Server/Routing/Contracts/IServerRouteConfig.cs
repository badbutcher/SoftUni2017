namespace HandMadeHttpServer.Server.Routing.Contracts
{
    using System.Collections.Generic;
    using HandMadeHttpServer.Server.Enums;

    public interface IServerRouteConfig
    {
        Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}