using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001
{
    class Startup
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee()
            {
                FirstName = "Pavel",
                LastName = "Nikolov",
                Address = "Lozenec",
                Birthday = DateTime.Now,
                Salary = 9999.99m
            };

            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());
            EmployeeDto dbo = Mapper.Map<EmployeeDto>(emp);

            Console.WriteLine($"{dbo.FirstName}   {dbo.LastName}   {dbo.Salary}");
        }
    }
}
