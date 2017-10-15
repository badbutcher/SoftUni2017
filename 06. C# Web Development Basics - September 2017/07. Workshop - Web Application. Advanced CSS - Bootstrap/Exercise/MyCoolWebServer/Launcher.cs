namespace MyCoolWebServer
{
    using MyCoolWebServer.GameStoreApplication;
    using Server;
    using Server.Contracts;
    using Server.Routing;

    public class Launcher : IRunnable
    {
        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            GameStoreApp mainApplication = new GameStoreApp();
            mainApplication.InitializeDatabase();

            //ByTheCakeApp mainApplication = new ByTheCakeApp();
            //mainApplication.InitializeDatabase();

            AppRouteConfig appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            WebServer webServer = new WebServer(8230, appRouteConfig);

            webServer.Run();
        }
    }
}