namespace BookShop.Data.Models
{
    public class CategoryBooks
    {
        public int CategoryId { get; set; }

        public Categorie Categorie { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}