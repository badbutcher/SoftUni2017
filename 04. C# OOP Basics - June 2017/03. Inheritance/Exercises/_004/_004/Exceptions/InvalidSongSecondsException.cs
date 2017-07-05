namespace _004.Exceptions
{
    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        public InvalidSongSecondsException(string message)
            : base(message)
        {
        }
    }
}