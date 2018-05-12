namespace FestivalManager.Entities
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Stage : IStage
    {
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets
        {
            get
            {
                return this.sets.AsReadOnly();
            }
        }

        public IReadOnlyCollection<ISong> Songs
        {
            get
            {
                return this.songs.AsReadOnly();
            }
        }

        public IReadOnlyCollection<IPerformer> Performers
        {
            get
            {
                return this.performers.AsReadOnly();
            }
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer); //???
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(a => a.Name == name);

            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(a => a.Name == name);

            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(a => a.Name == name);

            return song;
        }

        public bool HasPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(a => a.Name == name);

            if (performer == null)
            {
                return false;
            }

            return true;
        }

        public bool HasSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(a => a.Name == name);

            if (set == null)
            {
                return false;
            }

            return true;
        }

        public bool HasSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(a => a.Name == name);

            if (song == null)
            {
                return false;
            }

            return true;
        }

        //public override string ToString()
        //{
        //    return $"Festival length: {this.songs.Sum(a=>a.Duration.Minutes)}";
        //}
    }
}