namespace _004
{
    using _004.Exceptions;

    public class Song
    {
        private string artistName;
        private string songName;
        private string duration;

        public Song(string artistName, string songName, string duration)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Duration = duration;
        }

        public string ArtistName
        {
            get
            {
                return this.artistName;
            }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException("Artist name should be between 3 and 20 symbols.");
                }

                this.artistName = value;
            }
        }

        public string SongName
        {
            get
            {
                return this.songName;
            }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidSongNameException("Song name should be between 3 and 30 symbols.");
                }

                this.songName = value;
            }
        }

        public string Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                string[] data = value.Split(':');
                long minutes = long.Parse(data[0]);
                long seconds = long.Parse(data[1]);
                long totalSeconds = minutes * 60 + seconds;
                if (totalSeconds < 0 || totalSeconds > 899)
                {
                    throw new InvalidSongLengthException("Invalid song length.");
                }

                if (minutes < 0 || minutes > 14)
                {
                    throw new InvalidSongMinutesException("Song minutes should be between 0 and 14.");
                }

                if (seconds < 0 || seconds > 59)
                {
                    throw new InvalidSongSecondsException("Song seconds should be between 0 and 59.");
                }

                this.duration = value;
            }
        }
    }
}