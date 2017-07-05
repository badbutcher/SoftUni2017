using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    public class Worker : Human
    {
        private decimal weeklySalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weeklySalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeeklySalary = weeklySalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeeklySalary
        {
            get
            {
                return this.weeklySalary;
            }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weeklySalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyEarned()
        {
            var result = (WeeklySalary / 5) / WorkHoursPerDay;
            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("First Name: ").AppendLine(this.FirstName)
                .Append("Last Name: ").AppendLine(this.LastName)
                .Append("Week Salary: ").AppendLine($"{this.WeeklySalary:F2}")
                .Append("Hours per day: ").AppendLine($"{this.WorkHoursPerDay:F2}")
                .Append("Salary per hour: ").AppendLine($"{this.MoneyEarned():F2}")
                .AppendLine();

            return sb.ToString();
        }
    }
}