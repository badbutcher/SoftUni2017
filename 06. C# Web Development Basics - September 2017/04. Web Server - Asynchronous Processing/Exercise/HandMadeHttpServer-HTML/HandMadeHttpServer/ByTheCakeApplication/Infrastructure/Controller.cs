namespace HandMadeHttpServer.ByTheCakeApplication.Infrastructure
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using HandMadeHttpServer.ByTheCakeApplication.Views;
    using HandMadeHttpServer.Server.HTTP.Contracts;
    using HandMadeHttpServer.Server.HTTP.Response;

    public abstract class Controller
    {
        public const string DefaultPath = @"ByTheCakeApplication\Resources\{0}.html";
        public const string ContentPlaceholder = "{{{content}}}";

        public IHttpResponse FileViewResponse(string fileName)
        {
            string result = this.ProcessFileHtml(fileName);

            return new ViewResponse(HttpStatusCode.OK, new FileView(result));
        }

        public IHttpResponse FileViewResponse(string fileName, Dictionary<string, string> values)
        {
            string result = this.ProcessFileHtml(fileName);

            if (values != null && values.Any())
            {
                foreach (var value in values)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.OK, new FileView(result));
        }

        private string ProcessFileHtml(string fileName)
        {
            string layoutHtml = File.ReadAllText(string.Format(DefaultPath, "layout"));

            string fileHtml = File
                .ReadAllText(string.Format(DefaultPath, fileName));

            string result = layoutHtml.Replace(ContentPlaceholder, fileHtml);

            return result;
        }
    }
}