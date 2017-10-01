namespace WebServer.Server.Http
{
    using System;
    using System.Collections.Generic;
    using WebServer.Server.Common;
    using WebServer.Server.Http.Contracts;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));

            string key = header.Key;

            this.headers[key] = header;
        }

        public bool ContainsKey(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));

            if (!this.headers.ContainsKey(key))
            {
                throw new InvalidOperationException($"The give key {key} is not present in the headers collection.");
            }

            return this.headers[key];
        }

        public override string ToString() => string.Join(Environment.NewLine, this.headers);
    }
}