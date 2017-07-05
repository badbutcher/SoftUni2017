using System;

namespace _004.Exceptions
{
    public class InvalidSongException : Exception
    {
        public InvalidSongException(string message)
            : base(message)
        {
        }
    }
}