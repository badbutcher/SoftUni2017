namespace MyCoolWebServer.Server.Http.Response
{
    using System;
    using Enums;
    using MyCoolWebServer.Server.Common;

    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex))
        {
        }
    }
}