namespace BookShop.Services.Models
{
    using System.Collections.Generic;

    public class FullBookInfoServiceModel
    {
        public int AuthorId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public int Edition { get; set; }

        public List<string> BooksCategory { get; set; }
    }
}