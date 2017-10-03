namespace HandMadeHttpServer.Server.HTTP
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using HandMadeHttpServer.Server.Enums;
    using HandMadeHttpServer.Server.Exceptions;
    using HandMadeHttpServer.Server.HTTP.Contracts;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.FromData = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }

        public IDictionary<string, string> FromData { get; private set; }

        public HttpHeaderCollection HeaderCollection { get; private set; }

        public string Path { get; private set; }

        public IDictionary<string, string> QueryParameters { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public string Url { get; private set; }

        public IDictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameter(string key, string value)
        {
            this.UrlParameters[key] = value;
        }

        private void ParseRequest(string requestString)
        {
            string[] requestLines = requestString
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine = requestLines[0].Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException("Invalid request line.");
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());
            this.Url = requestLine[1];
            this.Path = this.Url
                .Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

            this.ParseHeaders(requestLines);
            this.ParseParameters();

            if (this.RequestMethod == HttpRequestMethod.POST)
            {
                this.ParseQuery(requestLines[requestLines.Length - 1], this.FromData);
            }
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            string query = this.Url.Split('?')[1];
            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, IDictionary<string, string> queryParameters)
        {
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split('&');
            foreach (string queryPair in queryPairs)
            {
                string[] queryArgs = queryPair.Split('=');
                if (queryArgs.Length != 2)
                {
                    continue;
                }

                queryParameters.Add(WebUtility.UrlDecode(queryArgs[0]), WebUtility.UrlDecode(queryArgs[1]));
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            int endIndex = Array.IndexOf(requestLines, string.Empty);
            for (int i = 1; i < endIndex; i++)
            {
                string[] headerArgs = requestLines[i]
                    .Split(new[] { ": " }, StringSplitOptions.None);

                string key = headerArgs[0];
                string value = headerArgs[1].Trim();
                HttpHeader header = new HttpHeader(key, value);

                this.HeaderCollection.Add(header);
            }

            if (!this.HeaderCollection.ContainsKey("Host"))
            {
                throw new BadRequestException("Host not found.");
            }
        }

        private HttpRequestMethod ParseRequestMethod(string value)
        {
            if (Enum.TryParse(value, out HttpRequestMethod request))
            {
                return request;
            }
            else
            {
                throw new BadRequestException("Invalid request type.");
            }
        }
    }
}