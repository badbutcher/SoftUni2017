namespace _007.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using _007.Models.ManyToMany;

    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<ItemOrder> Orders { get; set; } = new List<ItemOrder>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}