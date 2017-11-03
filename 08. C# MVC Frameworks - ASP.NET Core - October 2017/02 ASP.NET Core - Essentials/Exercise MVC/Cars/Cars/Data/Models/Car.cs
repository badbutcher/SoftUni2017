namespace Exercise.Data.Models
{
    using System.Collections.Generic;

    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public IList<Sale> Sales { get; set; } = new List<Sale>();

        public IList<PartCars> Parts { get; set; } = new List<PartCars>();
    }
}