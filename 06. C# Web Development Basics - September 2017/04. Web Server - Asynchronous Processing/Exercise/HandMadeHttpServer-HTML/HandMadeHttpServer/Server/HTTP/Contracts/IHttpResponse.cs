namespace HandMadeHttpServer.Server.HTTP.Contracts
{
    public interface IHttpResponse
    {
        string Response { get; }

        void AddHeader(string location, string url);
    }
}