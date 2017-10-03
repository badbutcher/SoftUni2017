namespace HandMadeHttpServer.Server.HTTP.Response
{
    using System.Net;
    using System.Text;
    using HandMadeHttpServer.Server.Contracts;
    using HandMadeHttpServer.Server.HTTP.Contracts;

    public abstract class HttpResponse : IHttpResponse
    {
        private readonly IView view;

        protected HttpResponse(string redirectUrl)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader("Location", redirectUrl);
        }

        protected HttpResponse(HttpStatusCode responseCode, IView view)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.view = view;
            this.StatusCode = responseCode;
        }

        private HttpHeaderCollection HeaderCollection { get; set; }

        private HttpStatusCode StatusCode { get; set; }

        private string StatusMessage => this.StatusCode.ToString();

        public string Response
        {
            get
            {
                StringBuilder response = new StringBuilder();

                int statusCodeNumber = (int)this.StatusCode;
                response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.StatusCode.ToString()}");

                response.AppendLine(this.HeaderCollection.ToString());
                response.AppendLine();

                if ((int)this.StatusCode < 300 || (int)this.StatusCode > 400)
                {
                    response.AppendLine(this.view.View());
                }

                return response.ToString();
            }
        }

        public void AddHeader(string location, string url)
        {
            this.HeaderCollection.Add(new HttpHeader(location, url));
        }
    }
}