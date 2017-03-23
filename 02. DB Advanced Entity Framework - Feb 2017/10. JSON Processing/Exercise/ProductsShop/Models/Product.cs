namespace ProductsShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Categorie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
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