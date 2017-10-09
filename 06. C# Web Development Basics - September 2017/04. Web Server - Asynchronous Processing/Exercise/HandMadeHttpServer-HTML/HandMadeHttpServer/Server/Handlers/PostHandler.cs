namespace HandMadeHttpServer.Server.Handlers
{
    using System;
    using HandMadeHttpServer.Server.HTTP.Contracts;

    public class PostHandler : RequestHandler
    {
        public PostHandler(Func<IHttpRequest, IHttpResponse> func)
            : base(func)
        {
        }
    }
}