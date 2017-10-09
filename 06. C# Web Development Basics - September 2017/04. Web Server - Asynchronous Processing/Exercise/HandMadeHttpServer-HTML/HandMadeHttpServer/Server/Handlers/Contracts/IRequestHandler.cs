namespace HandMadeHttpServer.Server.Handlers.Contracts
{
    using HandMadeHttpServer.Server.HTTP.Contracts;

    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext httpContext);
    }
}