namespace Sale.Models
{
    using System.Collections.Generic;

    public class StoreLocation
    {
        public StoreLocation()
        {
            this.SalesInStore = new List<_Sale>();
        }

        public int Id { get; set; }
        public string LocationName { get; set; }
        public List<_Sale> SalesInStore { get; set; }
    }
}