namespace _008
{
    using System;
    using System.Data.Entity.Validation;

    class Program
    {
        static void Main()
        {
            try
            {
                UsersContext dbContext = new UsersContext();

                dbContext.Users.Add(new Users()
                {
                    Username = "pesewq23ho",
                    Password = "1234d56A789%",
                    Email = "pavel.p.n@abv.bg",
                    Age = 5
                });

                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var err in e.EntityValidationErrors)
                {
                    foreach (var er in err.ValidationErrors)
                    {
                        Console.WriteLine(er.ErrorMessage);
                    }
                }
            }
        }
    }
}