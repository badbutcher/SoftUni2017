using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSystem.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}