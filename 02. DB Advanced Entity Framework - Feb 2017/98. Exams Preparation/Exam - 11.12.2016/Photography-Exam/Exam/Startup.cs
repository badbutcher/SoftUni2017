namespace Exam
{
    class Startup
    {
        static void Main()
        {
            PhotoContext context = new PhotoContext();
            context.Database.Initialize(true);
        }
    }
}