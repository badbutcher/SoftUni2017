using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Server.Exceptions
{
    public class InvalidResponseExeption : Exception
    {
        public InvalidResponseExeption(string message)
            : base(message)
        {

        }
    }
}
