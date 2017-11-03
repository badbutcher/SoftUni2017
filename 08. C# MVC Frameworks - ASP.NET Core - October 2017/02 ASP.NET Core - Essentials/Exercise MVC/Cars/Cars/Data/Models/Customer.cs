namespace Exercise.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public IList<Sale> Sales { get; set; } = new List<Sale>();
    }
}