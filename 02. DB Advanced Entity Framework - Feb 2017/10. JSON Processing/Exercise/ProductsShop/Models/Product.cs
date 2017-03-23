using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Models
{
    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Categorie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(3)]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        public int? BuyerId { get; set; }

        public virtual User Buyer { get; set; }

        public int SellerId { get; set; }

        public virtual User Seller { get; set; }

        public virtual ICollection<Categorie> Categories { get; set; }
    }
}
