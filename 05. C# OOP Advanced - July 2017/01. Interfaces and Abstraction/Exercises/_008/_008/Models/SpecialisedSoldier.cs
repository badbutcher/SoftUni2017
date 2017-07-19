using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _008.Interfaces;

namespace _008.Models
{
    public abstract class SpecialisedSoldier : ISpecialisedSoldier
    {
        public string Corp { get; set; }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public double Salary => throw new NotImplementedException();
    }
}