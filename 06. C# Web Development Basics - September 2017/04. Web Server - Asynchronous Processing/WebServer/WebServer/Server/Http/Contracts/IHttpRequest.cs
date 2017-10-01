namespace WebServer.Server.Http.Contracts
{
    using System.Collections.Generic;
    using WebServer.Server.Enums;

    public interface IHttpRequest
    {
        IDictionary<string, string> FromData { get; }

        HttpHeaderCollection Headers { get; }

        string Path { get; }

        IDictionary<string, string> QueryParameters { get; }

        HttpRequestMethod Method { get; }

        string Url { get; }

        IDictionary<string, string> UrlParameters { get; }

        void AddUrlParameter(string key, string value);
    }
}