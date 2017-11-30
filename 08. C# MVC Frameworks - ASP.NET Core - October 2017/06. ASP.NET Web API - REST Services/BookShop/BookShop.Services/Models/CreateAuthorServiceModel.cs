namespace BookShop.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateAuthorServiceModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}