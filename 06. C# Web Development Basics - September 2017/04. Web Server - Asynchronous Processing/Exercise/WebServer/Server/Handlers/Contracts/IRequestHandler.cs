namespace WebServer.Server.Handlers.Contracts
{
    using WebServer.Server.HTTP.Contracts;

    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpResponse httpContext);
    }
}