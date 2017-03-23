using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Models
{
    public class User
    {
        public User()
        {
            this.Friends = new HashSet<User>();
            this.ProductsSold = new HashSet<Product>();
            this.ProductsBought = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        [InverseProperty("Seller")]
        public virtual ICollection<Product> ProductsSold { get; set; }

        [InverseProperty("Buyer")]
        public virtual ICollection<Product> ProductsBought { get; set; }
    }
}
