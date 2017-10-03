namespace HandMadeHttpServer.Server.HTTP.Contracts
{
    using System.Collections.Generic;
    using HandMadeHttpServer.Server.Enums;

    public interface IHttpRequest
    {
        IDictionary<string, string> FromData { get; }

        HttpHeaderCollection HeaderCollection { get; }

        string Path { get; }

        IDictionary<string, string> QueryParameters { get; }

        HttpRequestMethod RequestMethod { get; }

        string Url { get; }

        IDictionary<string, string> UrlParameters { get; }

        void AddUrlParameter(string key, string value);
    }
}