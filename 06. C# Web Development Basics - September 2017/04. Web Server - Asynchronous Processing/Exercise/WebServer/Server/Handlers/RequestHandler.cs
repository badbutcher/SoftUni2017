namespace WebServer.Server.Handlers
{
    using WebServer.Server.Handlers.Contracts;
    using WebServer.Server.HTTP.Contracts;

    public abstract class RequestHandler : IRequestHandler
    {
        public IHttpResponse Handle(IHttpResponse httpContext)
        {
            //IHttpResponse httpResponse = null;

            //httpResponse.AddHeader("Content-Type", "text/html");

            //return httpResponse;

            return null;
        }
    }
}