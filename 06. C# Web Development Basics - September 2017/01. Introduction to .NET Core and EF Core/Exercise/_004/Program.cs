namespace _004
{
    using _004.Models;

    public class Program
    {
        public static void Main()
        {
            MyDbContext context = new MyDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            User user = new User()
            {
                Username = "eeleaaelelelell",
                Password = "aaa",
                Email = "--123@gmail.com",
                Age = 1111
            };

            user.Age = 123214;

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}