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
            Employee manager = new Employee()
            {
                FirstName = "Smint",
                LastName = "Dominos",
                Birthday = DateTime.Now,
                Salary = 123.45m,
                IsOnHoliday = false,
                Address = "Sofai",
                Manager = new Employee()
                {
                    FirstName = "Frank",
                    LastName = "Loid"
                },
                Employees = new List<Employee>()
            };

            Employee e1 = new Employee()
            {
                FirstName = "Pacha",
                LastName = "Salza",
                Birthday = DateTime.Now,
                Salary = 423.45m,
                IsOnHoliday = true,
                Address = "Varna",
                Manager = manager
            };

            Employee e2 = new Employee()
            {
                FirstName = "Midea",
                LastName = "Plantinet",
                Birthday = DateTime.Now,
                Salary = 9000.00m,
                IsOnHoliday = true,
                Address = "Varna",
                Manager = manager
            };

            Employee e3 = new Employee()
            {
                FirstName = "Q",
                LastName = "Vi",
                Birthday = DateTime.Now,
                Salary = 0.50m,
                IsOnHoliday = true,
                Address = "Ruse",
                Manager = manager
            };

           
        }
    }
}
