namespace _006.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}