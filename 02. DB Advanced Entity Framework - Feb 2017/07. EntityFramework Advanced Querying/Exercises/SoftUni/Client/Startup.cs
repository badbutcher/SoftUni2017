namespace SoftUni
{
    using System;
    using Data;
    using Models;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            ////_017(context);
            ////_018(context);
        }

        private static void _018(SoftUniContext context)
        {
            var result = context.Departments
                .Select(e => new
                {
                    e.Name,
                    Sum = e.Employees.Sum(s => s.Salary)
                })
                .Where(s => s.Sum < 30000 || s.Sum > 70000);

            foreach (var item in result)
            {
                Console.WriteLine("{0} - {1:F2}", item.Name, item.Sum);
            }
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