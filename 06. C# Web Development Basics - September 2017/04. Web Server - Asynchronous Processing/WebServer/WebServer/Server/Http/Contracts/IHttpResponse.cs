namespace WebServer.Server.Http.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        HttpHeaderCollection Headers { get; }
    }
}