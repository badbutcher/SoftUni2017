namespace MassDefect
{
    class Startup
    {
        static void Main()
        {
            MassDefectContext context = new MassDefectContext();
            context.Database.Initialize(true);
        }
    }
}