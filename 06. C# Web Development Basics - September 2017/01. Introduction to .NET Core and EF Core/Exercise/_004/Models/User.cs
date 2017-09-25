namespace _004.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using _004.Validations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [CustomValidation(typeof(ValidatePasswordAttribute), "CorrectPassword")]
        //[ValidatePassword]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"\b(?<![\.\-])([a-zA-Z0-9\.\-]+)@([a-zA-Z\-]+)\.([a-zA-Z\-\.]+)\b")]
        //[RegularExpression(@"[0-9]+")]
        public string Email { get; set; }

        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}