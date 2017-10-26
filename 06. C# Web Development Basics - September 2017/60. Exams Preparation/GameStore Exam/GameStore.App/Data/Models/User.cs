namespace GameStore.App.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}