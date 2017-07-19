using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _008.Interfaces;

namespace _008.Models
{
    public class LeutenantGeneral : ILeutenantGeneral
    {
        public LeutenantGeneral(int id, string firstName, string lastName, double salary, IList<IPrivate> privates)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Privates = new List<IPrivate>();
        }

        public IList<IPrivate> Privates { get; private set; }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public double Salary { get; private set; }
    }
}