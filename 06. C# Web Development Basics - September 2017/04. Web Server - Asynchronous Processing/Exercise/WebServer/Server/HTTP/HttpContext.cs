namespace WebServer.Server.HTTP
{
    using WebServer.Server.HTTP.Contracts;

    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(string requestStr)
        {
            this.request = new HttpRequest(requestStr);
        }

        //TODO: ???
        public IHttpRequest Request { get => this.request; }
    }
}