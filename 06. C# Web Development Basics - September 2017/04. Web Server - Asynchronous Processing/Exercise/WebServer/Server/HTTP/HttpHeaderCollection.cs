namespace WebServer.Server.HTTP
{
    using System;
    using System.Collections.Generic;
    using WebServer.Server.HTTP.Contracts;

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
            //return this.headers.ContainsKey(key);

            if (this.headers.ContainsKey(key))
            {
                return true;
            }
            else
            {
                return false;
            }
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
            string returnValue = string.Join(Environment.NewLine, this.headers);

            return returnValue;
        }
    }
}