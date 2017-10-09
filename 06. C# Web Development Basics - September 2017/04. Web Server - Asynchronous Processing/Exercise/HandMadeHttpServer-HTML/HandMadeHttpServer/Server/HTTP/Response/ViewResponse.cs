namespace HandMadeHttpServer.Server.HTTP.Response
{
    using System.Net;
    using HandMadeHttpServer.Server.Contracts;

    public class ViewResponse : HttpResponse
    {
        public ViewResponse(HttpStatusCode responseCode, IView view)
            : base(responseCode, view)
        {
        }
    }
}