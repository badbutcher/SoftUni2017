namespace _007.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using _007.Validations;

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
        [ValidatePasswordAttribute]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"\b(?<![\.\-])([a-zA-Z0-9\.\-]+)@([a-zA-Z\-]+)\.([a-zA-Z\-\.]+)\b")]
        public string Email { get; set; }

        public byte[] ProfilePicture { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int? Age { get; set; }

        public bool IsDeleted { get; set; }

        public List<Friendship> FromFriends { get; set; } = new List<Friendship>();

        public List<Friendship> ToFriends { get; set; } = new List<Friendship>();

        public List<Album> Albums { get; set; } = new List<Album>();
    }
}