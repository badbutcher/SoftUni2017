using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServer.Server.Contracts;
using WebServer.Server.Exceptions;

namespace WebServer.Server.Http.Response
{
    public class ViewResponse : HttpResponse
    {
        private readonly IView view;

        public ViewResponse(HttpStatusCode statusCode, IView view)
        {
            this.ValidateStatsCode(statusCode);

            this.view = view;
            this.StatusCode = statusCode;
        }

        private void ValidateStatsCode(HttpStatusCode statusCode)
        {
            var statusCodeNumber = (int)statusCode;

            if (299 < statusCodeNumber && statusCodeNumber < 400)
            {
                throw new InvalidResponseExeption("View responses needs a status code below 300 and above 400 (inclusuve).");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.view.View()}";
        }
    }
}