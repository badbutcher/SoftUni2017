namespace _009.Models.ManyToMany
{
    public class ItemOrder
    {
        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}