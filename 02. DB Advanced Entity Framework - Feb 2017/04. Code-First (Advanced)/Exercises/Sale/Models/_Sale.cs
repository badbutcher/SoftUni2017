namespace Sale.Models
{
    using System;

    public class _Sale
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public StoreLocation StoreLocation { get; set; }
        public DateTime Date { get; set; }
    }
}