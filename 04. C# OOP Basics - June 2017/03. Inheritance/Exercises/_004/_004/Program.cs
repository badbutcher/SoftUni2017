namespace _004
{
    using _004.Exceptions;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            List<Song> songs = new List<Song>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] data = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    string artistName = data[0];
                    string songName = data[1];
                    string duration = data[2];
                    Song song = new Song(artistName, songName, duration);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Songs added: {0}", songs.Count);
            GetDuration(songs);
        }

        private static void GetDuration(List<Song> songs)
        {
            long totalSeconds = 0;
            foreach (var item in songs)
            {
                string[] data = item.Duration.Split(':');
                long minutes = long.Parse(data[0]);
                long seconds = long.Parse(data[1]);
                totalSeconds += minutes * 60 + seconds;
            }

            TimeSpan time = TimeSpan.FromSeconds(totalSeconds);
            string answer = string.Format("Playlist length: {0:}h {1}m {2}s",
                time.Hours,
                time.Minutes,
                time.Seconds);

            Console.WriteLine(answer);
        }
    }
}