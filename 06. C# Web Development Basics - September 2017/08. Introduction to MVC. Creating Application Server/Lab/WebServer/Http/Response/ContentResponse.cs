namespace WebServer.Http.Response
{
    using Enums;
    using Exceptions;

    public class ContentResponse : HttpResponse
    {
        private readonly string content;

        public ContentResponse(HttpStatusCode statusCode, string content)
        {
            this.ValidateStatusCode(statusCode);

            this.content = content;
            this.StatusCode = statusCode;

            this.Headers.Add(HttpHeader.ContentType, "text/html");
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.content}";
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            var statusCodeNumber = (int)statusCode;

            if (statusCodeNumber > 299 && statusCodeNumber < 400)
            {
                throw new InvalidResponseException("View responses need a status code below 300 and above 400 (inclusive).");
            }
        }
    }
}