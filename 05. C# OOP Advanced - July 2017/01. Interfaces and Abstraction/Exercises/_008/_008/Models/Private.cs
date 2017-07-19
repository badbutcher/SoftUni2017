using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _008.Interfaces;

namespace _008.Models
{
    public class Private : IPrivate
    {
        public Private(double salary, int id, string firstName, string lastName)
        {
            this.Salary = salary;
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public double Salary { get; private set; }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}";
        }
    }
}