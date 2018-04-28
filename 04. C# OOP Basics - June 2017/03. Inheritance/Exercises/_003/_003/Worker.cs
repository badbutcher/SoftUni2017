namespace _003
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private double weeklySalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weeklySalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeeklySalary = weeklySalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeeklySalary
        {
            get
            {
                return this.weeklySalary;
            }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weeklySalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public double MoneyEarned()
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