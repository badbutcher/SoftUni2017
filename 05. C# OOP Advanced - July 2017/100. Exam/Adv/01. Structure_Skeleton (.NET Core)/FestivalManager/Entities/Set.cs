namespace FestivalManager.Entities
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Set : ISet
    {
        private readonly List<IPerformer> performers;
        private readonly List<ISong> songs;

        protected Set(string name, TimeSpan maxDuration)
        {
            this.Name = name;
            this.MaxDuration = maxDuration;

            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public string Name { get; private set; }

        public TimeSpan MaxDuration { get; private set; }

        public TimeSpan ActualDuration
        {
            get
            {
                var time = new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));

                return time;
            }
        }

        public IReadOnlyCollection<IPerformer> Performers
        {
            get
            {
                return this.performers.AsReadOnly();
            }
        }

        public IReadOnlyCollection<ISong> Songs
        {
            get
            {
                return this.songs.AsReadOnly();
            }
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            if (song.Duration + this.ActualDuration > this.MaxDuration)
            {
                throw new InvalidOperationException("Song is over the set limit!");
            }

            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            if (this.performers.Count == 0)
            {
                return false;
            }

            if (this.songs.Count == 0)
            {
                return false;
            }

            bool allPerformersHaveInstruments = this.performers.All(p => p.Instruments.Any());

            if (!allPerformersHaveInstruments)
            {
                return false;
            }

            var allPerformersHaveFunctioningInstruments = this.performers.All(p => p.Instruments.Any(i => !i.IsBroken));

            if (!allPerformersHaveFunctioningInstruments)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Join(", ", this.Performers));

            foreach (var song in this.Songs)
            {
                sb.AppendLine($"-- {song}");
            }

            var result = sb.ToString();
            return result;
        }
    }
}