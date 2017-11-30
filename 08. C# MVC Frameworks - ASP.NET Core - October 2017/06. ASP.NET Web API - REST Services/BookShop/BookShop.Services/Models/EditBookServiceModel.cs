namespace BookShop.Services.Models
{
    public class EditBookServiceModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public int AuthorId { get; set; }

        public int Edition { get; set; }
    }
}