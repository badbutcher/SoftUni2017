namespace WebServer.Server.HTTP
{
    public class HttpHeader
    {
        public HttpHeader(string key, string value)
        {
            //Good idea
            //if (key == null)
            //{
            //    throw new ArgumentException(nameof(key));
            //}

            //if (value == null)
            //{
            //    throw new ArgumentException(nameof(value));
            //}

            this.Key = key;
            this.Value = value;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
        {
            string returnValue = this.Key + ": " + this.Value;

            return returnValue;
        }
    }
}