namespace _004.Exceptions
{
    public class InvalidSongMinutesException : InvalidSongLengthException
    {
        public InvalidSongMinutesException(string message)
            : base(message)
        {
        }
    }
}