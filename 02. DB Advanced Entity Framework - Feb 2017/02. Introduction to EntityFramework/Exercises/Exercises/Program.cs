﻿using System;
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

            //_08AddressesByTownName();

            var context = new SoftuniContext();

            var employee = context.Employees
                .Where(e => e.EmployeeID == 147);

            var projects = context.Projects
                .OrderBy(p => p.Name);

            foreach (var item in employee)
            {
                Console.WriteLine("{0} {1} {2}",item.FirstName, item.LastName, item.JobTitle);
            }

            foreach (var item in projects)
            {
                Console.WriteLine("{0}", item.Name);
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

        private static void _06AddingANewAddressAndUpdatingEmployee()
        {
            var context = new SoftuniContext();

            var addres = new Address()
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };

            Employee employee = context.Employees.First(e => e.LastName == "Nakov");

            employee.Address = addres;
            context.SaveChanges();

            var result = context.Employees
                .OrderByDescending(e => e.AddressID)
                .Take(10);

            foreach (var item in result)
            {
                Console.WriteLine(item.Address.AddressText);
            }
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
