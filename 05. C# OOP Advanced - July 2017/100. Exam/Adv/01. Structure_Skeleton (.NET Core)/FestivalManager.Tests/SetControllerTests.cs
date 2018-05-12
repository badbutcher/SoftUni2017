// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void SetControllerReturnsDidNotPerform()
        {
            Stage stage = new Stage();
            ISet set = new Short("Short set");
            ISong song = new Song("Song name", new TimeSpan(0, 10, 0));
            IPerformer performer = new Performer("Name", 22);

            stage.AddSet(set);
            stage.AddSong(song);
            stage.AddPerformer(performer);

            SetController controller = new SetController(stage);

            string expected = "1. Short set:\r\n-- Did not perform";
            Assert.AreEqual(expected, controller.PerformSets());
        }

        [Test]
        public void SetControllerReturnsCorrectResult()
        {
            Stage stage = new Stage();
            ISet set = new Short("Short set");
            ISong song = new Song("Song name", new TimeSpan(0, 10, 0));
            IPerformer performer = new Performer("Name", 22);
            IInstrument instrument = new Guitar();

            performer.AddInstrument(instrument);

            stage.AddSet(set);
            stage.AddSong(song);
            stage.AddPerformer(performer);

            set.AddPerformer(performer);
            set.AddSong(song);

            SetController controller = new SetController(stage);

            string expected = "1. Short set:\r\n-- 1. Song name (10:00)\r\n-- Set Successful";
            Assert.AreEqual(expected, controller.PerformSets());
        }

        [Test]
        public void SetControllerWareInsturmentsDidNotPerform()
        {
            Stage stage = new Stage();
            ISet set = new Short("Short set");
            ISong song = new Song("Song name", new TimeSpan(0, 10, 0));
            IPerformer performer = new Performer("Name", 22);
            IInstrument instrument = new Guitar();

            performer.AddInstrument(instrument);

            stage.AddSet(set);
            stage.AddSong(song);
            stage.AddPerformer(performer);

            set.AddPerformer(performer);
            set.AddSong(song);

            SetController controller = new SetController(stage);
            controller.PerformSets();
            controller.PerformSets();
            controller.PerformSets();
            controller.PerformSets();

            string expected = "1. Short set:\r\n-- Did not perform";
            Assert.AreEqual(expected, controller.PerformSets());
        }
    }
}