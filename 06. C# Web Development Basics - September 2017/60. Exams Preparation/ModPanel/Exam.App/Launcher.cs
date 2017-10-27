namespace Exam.App
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        static Launcher()
        {
            using (ExamDbContext db = new ExamDbContext())
            {
                db.Database.Migrate();
            }
        }

        public static void Main() => MvcEngine.Run(new WebServer(8230, new ControllerRouter(), new ResourceRouter()));
    }
}