namespace CameraBazaar.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using CameraBazaar.Data.Infrastructure.Validation.Users;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public int Id { get; set; }

        [Username]
        public string Username { get; set; }

        [Email]
        public string Email { get; set; }

        [MinLength(3)]
        [Password]
        public string Password { get; set; }

        [PhoneNumber]
        public string PhoneNumber { get; set; }
    }
}