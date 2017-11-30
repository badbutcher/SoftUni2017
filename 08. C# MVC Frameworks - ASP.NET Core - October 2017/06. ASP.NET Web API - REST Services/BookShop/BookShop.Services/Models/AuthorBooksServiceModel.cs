namespace BookShop.Services.Models
{
    using System.Collections.Generic;

    public class AuthorBooksServiceModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Books { get; set; }
    }
}