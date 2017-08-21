public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        ISoldierFactory soldiersFactory = new SoldierFactory();
        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        IMissionFactory missionFactory = new MissionFactory();

        GameController gameController = new GameController(soldiersFactory, ammunitionFactory, missionFactory);

        Engine engine = new Engine(reader, writer, gameController);
        engine.Run();
    }
}