namespace _004.Exceptions
{
    public class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException(string message)
            : base(message)
        {
        }
    }
}