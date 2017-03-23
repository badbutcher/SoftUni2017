using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002
{
    class Startup
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> managers = CreateManagers();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>()
                .ForMember(dto => dto.EmployeesCount, configExpr => configExpr
                .MapFrom(e => e.Employees.Count));
            });

         
            IEnumerable<ManagerDto> managerDtos = Mapper.Map<IEnumerable<Employee>, IEnumerable<ManagerDto>>(managers);

            foreach (var item in managerDtos)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<Employee> CreateManagers()
        {
            var managers = new List<Employee>();
            for (int i = 0; i < 3; i++)
            {
                var manager = new Employee()
                {
                    FirstName = "Pesho",
                    LastName = "Peshev",
                    Address = "Sofia, Tintyava 10",
                    Birthday = new DateTime(1992, 3, 2),
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
                manager.Employees.Add(employee1);
                manager.Employees.Add(employee2);
                manager.Employees.Add(employee3);
                managers.Add(manager);
            }

            return managers;
        }
    }
}
