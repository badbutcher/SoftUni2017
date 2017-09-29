namespace WebServer.Server.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        public BadRequestException(string error)
        {
        }
    }
}