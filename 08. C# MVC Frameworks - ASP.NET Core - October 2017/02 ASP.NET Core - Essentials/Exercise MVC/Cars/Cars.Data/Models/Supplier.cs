namespace Cars.Data.Models
{
    using System.Collections.Generic;

    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public IList<Part> Parts { get; set; } = new List<Part>();
    }
}