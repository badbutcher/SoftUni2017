namespace HandMadeHttpServer.Server.Contracts
{
    using HandMadeHttpServer.Server.Routing.Contracts;

    public interface IApplication
    {
        void Start(IAppRouteConfig appRouteConfig);
    }
}