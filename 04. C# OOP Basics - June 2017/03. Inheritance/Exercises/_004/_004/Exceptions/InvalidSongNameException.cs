namespace _004.Exceptions
{
    internal class InvalidSongNameException : InvalidSongException
    {
        public InvalidSongNameException(string message)
            : base(message)
        {
        }
    }
}