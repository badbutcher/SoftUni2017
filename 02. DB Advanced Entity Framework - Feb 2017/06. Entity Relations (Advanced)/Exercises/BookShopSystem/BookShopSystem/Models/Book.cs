using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSystem.Models
{
    using Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.Design;

    public class Book
    {
        public Book()
        {
            this.Categorys = new HashSet<Category>();
            this.RelatedBooks = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        [Required]
        public virtual Author Author { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public EditionType EditionType { get; set; }

        public DateTime? RelaseDate { get; set; }

        [Required]
        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<Category> Categorys { get; set; }

        public virtual ICollection<Book> RelatedBooks { get; set; }
    }
}