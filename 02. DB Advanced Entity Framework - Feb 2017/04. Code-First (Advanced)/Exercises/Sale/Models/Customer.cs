namespace Sale.Models
{
    using System.Collections.Generic;

    public class Customer
    {
        public Customer()
        {
            this.SalesForCustomer = new List<_Sale>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public int Age { get; set; }
        public List<_Sale> SalesForCustomer { get; set; }
    }
}