namespace _010
{
    public class Program
    {
        public static void Main()
        {
            MyDbContext context = new MyDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}