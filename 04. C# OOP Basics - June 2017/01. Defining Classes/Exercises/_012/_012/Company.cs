using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012
{
    public class Company
    {
        private string name;
        private string department;
        private decimal salary;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }
}