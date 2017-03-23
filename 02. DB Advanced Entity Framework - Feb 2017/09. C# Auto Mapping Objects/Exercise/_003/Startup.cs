using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace _003
{
    class Startup
    {
        static void Main(string[] args)
        {

            //using (EmployeeContext context = new EmployeeContext())
            //{
            //    context.Database.Initialize(true);
            //    IEnumerable<Employee> managers = CreateManagers();
            //    EmployeeContext dbContext = new EmployeeContext();
            //    dbContext.Employees.AddRange(managers);
            //    dbContext.SaveChanges();
            //}

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                .ForMember(e => e.ManagerLastName, c => c.MapFrom(ee => ee.Manager.LastName));
            });

            using (EmployeeContext context = new EmployeeContext())
            {
                var employee = context.Employees
                    .Where(e => e.Birthday.Value.Year < 1990)
                    .OrderByDescending(e => e.Salary)
                    .ProjectTo<EmployeeDto>();

                foreach (var item in employee)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }


        private static IEnumerable<Employee> CreateManagers()
        {
            var managers = new List<Employee>();
            for (int i = 0; i < 4; i++)
            {
                var manager = new Employee()
                {
                    FirstName = "Pesho",
                    LastName = "Peshev",
                    Address = "Sofia, Tintyava 10",
                    Birthday = new DateTime(1989, 3, 2),
                    Employees = new List<Employee>(),
                    IsOnHoliday = false,
                    Manager = new Employee() { FirstName = "Ivan", LastName = "Ivanov" },
                    Salary = 100m
                };
                var employee1 = new Employee()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Salary = 120.20m,
                    Manager = manager
                };
                var employee2 = new Employee()
                {
                    FirstName = "Johny",
                    LastName = "Doing",
                    Salary = 120.22m,
                    Manager = manager
                };
                var employee3 = new Employee()
                {
                    FirstName = "Johnnie",
                    LastName = "Doable",
                    Salary = 120.23m,
                    Manager = manager
                };
                var employee4 = new Employee()
                {
                    FirstName = "Johnnie",
                    LastName = "Doable",
                    Salary = 120.23m,
                    Manager = null
                };
                manager.Employees.Add(employee1);
                manager.Employees.Add(employee2);
                manager.Employees.Add(employee3);
                manager.Employees.Add(employee4);
                managers.Add(manager);
            }

            return managers;
        }
    }
}
