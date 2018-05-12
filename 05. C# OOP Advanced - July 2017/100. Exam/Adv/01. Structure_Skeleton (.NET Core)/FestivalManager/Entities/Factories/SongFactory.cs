namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;

    public class SongFactory : ISongFactory
    {
        public ISong CreateSong(string name, TimeSpan duration)
        {
            var song = new Song(name, duration);
            return song;
        }
    }
}