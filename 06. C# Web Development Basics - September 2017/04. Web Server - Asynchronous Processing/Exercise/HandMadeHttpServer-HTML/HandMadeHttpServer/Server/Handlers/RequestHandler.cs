namespace HandMadeHttpServer.Server.Handlers
{
    using System;
    using HandMadeHttpServer.Server.Handlers.Contracts;
    using HandMadeHttpServer.Server.HTTP.Contracts;

    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> func;

        public RequestHandler(Func<IHttpRequest, IHttpResponse> func)
        {
            this.func = func;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            IHttpResponse httpResponse = this.func.Invoke(httpContext.Request);

            httpResponse.AddHeader("Content-Type", "text/html");

            return httpResponse;
        }
    }
}