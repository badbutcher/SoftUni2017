namespace WebServer.Server.Http
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WebServer.Server.Common;
    using WebServer.Server.Http.Contracts;

    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(HttpRequest request)
        {
            CoreValidator.ThrowIfNull(request, nameof(request));

            this.request = request;
        }

        public IHttpRequest Request => this.request;
    }
}
