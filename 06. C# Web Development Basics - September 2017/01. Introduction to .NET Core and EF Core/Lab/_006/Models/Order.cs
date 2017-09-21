namespace _006.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}