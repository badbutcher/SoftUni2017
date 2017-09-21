namespace _008.Models
{
    using System.Collections.Generic;
    using _008.Models.ManyToMany;

    public class Review
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<ItemOrder> Items { get; set; } = new List<ItemOrder>();

        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}