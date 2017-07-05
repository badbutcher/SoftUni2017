namespace _004.Exceptions
{
    public class InvalidArtistNameException : InvalidSongException
    {
        public InvalidArtistNameException(string message)
            : base(message)
        {
        }
    }
}