namespace _008.Models
{
    using _008.Interfaces;
    using System;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corp)
            : base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }

        public string Corp { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}" + Environment.NewLine + $"Corps: {this.Corp}";
        }
    }
}