namespace WebServer.Server.HTTP.Contracts
{
    using System.Net;
    using WebServer.Server.Contracts;

    public interface IHttpResponse
    {
        string Response { get; }

        void AddHeader(HttpStatusCode responseCode, IView view);
    }
}