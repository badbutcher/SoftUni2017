using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    class Program
    {
        static void Main()
        {
            //_03EmployeesFullInformation();
            //_04EmployeesWithSalaryOver50000();
            //_05EmployeesFromSeattle();
            //_06AddingANewAddressAndUpdatingEmployee();
            _7FindEmployeesInPeriod();
            //_08AddressesByTownName();
            //_9EmployeeWithId147();
            //_10DepartmentsWithMoreThan5Employees();
            //_11FindLatest10Projects();
            //_12IncreaseSalaries();
            //_13FindEmployeesByFirstNameStartingWithSA();
            //_14 e v "Part 2"
            //_15DeleteProjectById();
        }

        private static void _15DeleteProjectById()
        {
            var context = new SoftuniContext();

            var project = context.Projects.Find(2);

            foreach (var emp in project.Employees)
            {
                emp.Projects.Remove(project);
            }

            context.Projects.Remove(project);
            context.SaveChanges();

            var projects = context.Projects.Take(10);
            foreach (var pr in projects)
            {
                Console.WriteLine(pr.Name);
            }
        }

        private static void _13FindEmployeesByFirstNameStartingWithSA()
        {
            var context = new SoftuniContext();

            var result = context.Employees
                .Where(e => e.FirstName.Substring(0, 2) == "Sa");
            //.StartsWith("sa")

            foreach (var item in result)
            {
                Console.WriteLine("{0} {1} - {2} - (${3:F4})", item.FirstName, item.LastName, item.JobTitle, item.Salary);
            }
        }

        private static void _12IncreaseSalaries()
        {
            var context = new SoftuniContext();

            var salary = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing " || e.Department.Name == "Information Services");

            foreach (var item in salary)
            {
                item.Salary += (item.Salary * 12) / 100;
                //item.Salary *= 1.12;

                Console.WriteLine("{0} {1} (${2:F6})", item.FirstName, item.LastName, item.Salary);
            }

            context.SaveChanges();
        }
        private static void _11FindLatest10Projects()
        {
            var context = new SoftuniContext();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name);

            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Name} {project.Description} {project.StartDate:M/d/yyyy h:mm:ss tt} {project.EndDate:M/d/yyyy h:mm:ss tt}");
            }
        }

        private static void _10DepartmentsWithMoreThan5Employees()
        {
            var context = new SoftuniContext();

            var result = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count());


            foreach (Department departments in result)
            {
                Console.WriteLine("{0} {1}",
                    departments.Name,
                    departments.Employee.FirstName);

                foreach (var employee in departments.Employees)
                {
                    Console.WriteLine("{0} {1} {2}",
                        employee.FirstName,
                        employee.LastName,
                        employee.JobTitle);
                }
            }
        }
        private static void _9EmployeeWithId147()
        {
            var context = new SoftuniContext();

            var employee = context.Employees
                .Where(e => e.EmployeeID == 147);

            foreach (var item in employee)
            {
                Console.WriteLine("{0} {1} {2}", item.FirstName, item.LastName, item.JobTitle);

                foreach (var pro in item.Projects.OrderBy(p => p.Name))
                {
                    Console.WriteLine(pro.Name);
                }
            }
        }

        private static void _08AddressesByTownName()
        {
            var context = new SoftuniContext();

            var result = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .Take(10)
                .Select
                (
                    a => new
                    {
                        AddressName = a.AddressText,
                        TownName = a.Town.Name,
                        EmployeeName = a.Employees.Count
                    }
                );

            foreach (var address in result)
            {
                Console.WriteLine("{0}, {1} - {2} employees",
                   address.AddressName,
                   address.TownName,
                   address.EmployeeName);
            }
        }

        private static void _7FindEmployeesInPeriod()
        {
            //var context = new SoftuniContext();

            //var projectResult = context.Employees
            //    .Where(e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0)
            //    .Take(30);

            //foreach (var e in projectResult)
            //{
            //    Console.WriteLine($"{e.FirstName} {e.LastName} {e.Manager.FirstName}");

            //    foreach (var p in e.Projects)
            //    {
            //        Console.WriteLine($"--{p.Name} {p.StartDate:M/d/yyyy h:mm:ss tt} {p.EndDate:M/d/yyyy h:mm:ss tt}");
            //    }
            //}

            SoftuniContext context = new SoftuniContext();
            var emp = context.Employees;
            var proj = context.Projects;
            int counter = 1;

                var result = emp.Where(p => p.Projects.Count(x => x.StartDate.Year >= 2001 && x.StartDate.Year <= 2003) > 0).Take(30);
            foreach (var empl in result)
            {
                Console.WriteLine($"{empl.FirstName} {empl.LastName} {empl.Manager.FirstName}");

                foreach (var project in empl.Projects)
                {
                    Console.WriteLine($"--{project.Name} {project.StartDate:M/d/yyyy h:mm:ss tt} {project.EndDate:M/d/yyyy h:mm:ss tt}");
                }
            }
                


        }

        private static void _06AddingANewAddressAndUpdatingEmployee()
        {
            var context = new SoftuniContext();

            var addres = new Address()
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };

            Employee employee = context.Employees
                .First(e => e.LastName == "Nakov");

            employee.Address = addres;
            context.SaveChanges();

            var result = context.Employees
                .OrderByDescending(e => e.AddressID)
                .Take(10);

            foreach (var item in result)
            {
                Console.WriteLine(item.Address.AddressText);
            }

            // OR

            //Address address = new Address();
            //address.AddressText = "Vitoshka 15";
            //address.TownID = 4;

            //context.Addresses.Add(address);
            //context.SaveChanges();

            //Employee emp = context.Employees
            //    .FirstOrDefault(e => e.LastName == "Nakov");
            //emp.Address = address;
            //context.SaveChanges();

            //var addresses = context.Employees
            //    .OrderByDescending(e => e.AddressID)
            //    .Take(10)
            //    .ToList();

            //foreach (Employee e in addresses)
            //{
            //    Console.WriteLine(e.Address.AddressText);
            //}

            // OR 

            //Address address = new Address();
            //address.AddressText = "Vitoshka 15";
            //address.TownID = 4;

            //Employee emp = context.Employees
            //    .FirstOrDefault(e => e.LastName == "Nakov");
            //emp.Address = address;

            //context.SaveChanges();
        }

        private static void _05EmployeesFromSeattle()
        {
            var context = new SoftuniContext();
            var result = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName);

            foreach (var item in result)
            {
                Console.WriteLine("{0} {1} from {2} - ${3:F2}", item.FirstName, item.LastName, item.Department.Name, item.Salary);
            }
        }

        private static void _04EmployeesWithSalaryOver50000()
        {
            var context = new SoftuniContext();
            var result = context.Employees.Where(e => e.Salary > 50000);

            foreach (var item in result)
            {
                Console.WriteLine(item.FirstName);
            }
        }

        private static void _03EmployeesFullInformation()
        {
            var context = new SoftuniContext();
            var result = context.Employees;

            foreach (var item in result)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",
                    item.FirstName,
                    item.LastName,
                    item.MiddleName,
                    item.JobTitle,
                    item.Salary);
            }
        }
    }
}
