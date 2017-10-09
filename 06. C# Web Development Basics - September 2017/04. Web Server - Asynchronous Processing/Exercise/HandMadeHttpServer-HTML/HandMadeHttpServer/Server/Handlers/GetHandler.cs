namespace HandMadeHttpServer.Server.Handlers
{
    using System;
    using HandMadeHttpServer.Server.HTTP.Contracts;

    public class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpRequest, IHttpResponse> func)
            : base(func)
        {
        }
    }
}