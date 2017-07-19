using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _008.Interfaces;

namespace _008.Models
{
    public class Engineer : IEngineer
    {
        public Engineer(int id, string firstName, string lastName, double salary, string corp, IList<IRepair> parts)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Corp = corp;
            this.Parts = new List<IRepair>();
        }

        public IList<IRepair> Parts { get; private set; }

        public string Corp { get; set; }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public double Salary { get; set; }
    }
}