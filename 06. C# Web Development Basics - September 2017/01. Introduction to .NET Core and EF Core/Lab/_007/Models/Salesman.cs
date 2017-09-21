namespace _007.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Salesman
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}