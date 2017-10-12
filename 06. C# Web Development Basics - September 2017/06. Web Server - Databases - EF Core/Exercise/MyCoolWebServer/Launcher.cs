namespace MyCoolWebServer
{
    using ByTheCakeApplication;
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
            ByTheCakeApp mainApplication = new ByTheCakeApp();
            mainApplication.InitializeDatabase();

            AppRouteConfig appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            WebServer webServer = new WebServer(8230, appRouteConfig);

            webServer.Run();
        }
    }
}