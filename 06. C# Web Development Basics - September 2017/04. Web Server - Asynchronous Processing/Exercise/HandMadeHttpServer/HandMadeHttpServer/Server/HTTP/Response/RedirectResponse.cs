namespace HandMadeHttpServer.Server.HTTP.Response
{
    public class RedirectResponse : HttpResponse
    {
        protected RedirectResponse(string redirectUrl)
            : base(redirectUrl)
        {
        }
    }
}