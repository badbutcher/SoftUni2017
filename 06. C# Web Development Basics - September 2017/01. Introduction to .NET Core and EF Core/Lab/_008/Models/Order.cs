namespace _008.Models
{
    using System.Collections.Generic;
    using _008.Models.ManyToMany;

    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<ItemOrder> Items { get; set; } = new List<ItemOrder>();
    }
}