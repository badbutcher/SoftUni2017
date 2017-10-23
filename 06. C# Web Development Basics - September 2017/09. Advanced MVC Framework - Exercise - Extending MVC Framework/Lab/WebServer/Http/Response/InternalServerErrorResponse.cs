namespace WebServer.Http.Response
{
    using System;
    using Common;
    using Enums;

    public class InternalServerErrorResponse : ContentResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex).View())
        {
        }
    }
}