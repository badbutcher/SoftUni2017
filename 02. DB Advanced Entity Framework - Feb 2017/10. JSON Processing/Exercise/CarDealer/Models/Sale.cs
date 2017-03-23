using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public float Discount { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
