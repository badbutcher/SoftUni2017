namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;
    using System;
    using System.Linq;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private IStage stage;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;
        private ISongFactory songFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            ISet set = this.stage.GetSet(setName);
            ISong song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration:mm\\:ss}) to {setName}";
            throw new NotImplementedException();
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
            int totalFestivalMinutes = (int)totalFestivalLength.TotalMinutes;
            int totalFestivalSecond = (int)totalFestivalLength.TotalSeconds % 60;
            result += ($"Festival length: {totalFestivalMinutes:D2}:{totalFestivalSecond:D2}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                int totalMinutes = (int)set.ActualDuration.TotalMinutes;
                int totalSecond = (int)set.ActualDuration.TotalSeconds % 60;
                result += ($"--{set.Name} ({totalMinutes:D2}:{totalSecond:D2}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                {
                    result += ("--No songs played") + "\n";
                }
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.Trim('\n', '\r');
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return $"Registered {type} set";
        }

        public string RegisterSong(string[] args)
        {
            string songName = args[0];
            TimeSpan time = TimeSpan.ParseExact(args[1], "mm':'ss", null);

            ISong song = this.songFactory.CreateSong(songName, time);
            this.stage.AddSong(song);

            return $"Registered song {songName} ({song.Duration:mm\\:ss})";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string SignUpPerformer(string[] args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);
            var instruments = args.Skip(2);

            IPerformer performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var type in instruments)
            {
                IInstrument instrument = this.instrumentFactory.CreateInstrument(type);
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {name}";
        }
    }
}