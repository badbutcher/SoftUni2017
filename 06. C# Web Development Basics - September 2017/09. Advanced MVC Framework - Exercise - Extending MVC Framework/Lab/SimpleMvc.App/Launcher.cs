namespace SimpleMvc.App
{
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        public static void Main() =>
            MvcEngine.Run(new WebServer(8230, new ControllerRouter()));
    }
}