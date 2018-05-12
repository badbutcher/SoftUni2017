namespace FestivalManager
{
    using Core;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Entities;
    using FestivalManager.Core.IO;
    using FestivalManager.Core.IO.Contracts;
    using FestivalManager.Entities.Contracts;

    public static class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IStage stage = new Stage();
            IFestivalController festivalController = new FestivalController(stage);
            ISetController setController = new SetController(stage);

            Engine engine = new Engine(reader, writer, festivalController, setController);

            engine.Run();
        }
    }
}