namespace SoftUni
{
    using System;
    using Data;
    using Models;

    class Startup
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            _017(context);
        }

        private static void _017(SoftUniContext context)
        {
            string[] input = Console.ReadLine().Split();

            var result = context.Database.SqlQuery<ProjectViewModel>("EXEC dbo.pro_ReturnAllProjects {0}, {1}", input[0], input[1]);

            foreach (var item in result)
            {
                Console.WriteLine("{0} - {1}, {2}\n", item.Name, item.Description, item.StartDate);
            }
        }
    }
}