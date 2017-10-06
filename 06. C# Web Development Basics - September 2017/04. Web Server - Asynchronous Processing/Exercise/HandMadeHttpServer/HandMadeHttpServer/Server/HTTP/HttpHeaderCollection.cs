namespace HandMadeHttpServer.Server.HTTP
{
    using System;
    using System.Collections.Generic;
    using HandMadeHttpServer.Server.HTTP.Contracts;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            string key = header.Key;

            this.headers[key] = header;
        }

        public bool ContainsKey(string key)
        {
            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (this.ContainsKey(key))
            {
                HttpHeader header = this.headers[key];
                return header;
            }

            return null;
        }

        public override string ToString()
        {
            string returnValue = string.Join(Environment.NewLine, this.headers.Values);

            return returnValue;
        }
    }
}