namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0, 120)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 100000000)]
        public int Copies { get; set; }

        [Required]
        [Range(0, 120)]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [Required]
        [Range(0, 100)]
        public int Edition { get; set; }

        public List<CategoryBooks> Categories { get; set; } = new List<CategoryBooks>();
    }
}