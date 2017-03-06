namespace _008
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Users
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&*()_+<>?])[A-Za-z\d$@$!%*?&*()_+<>?]+")]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [RegularExpression(@"^[^.\-_].*[^.\-_]\@[^.].*[^.]")]
        public string Email { get; set; }

        [Range(0, 1024)]
        public byte ProfilePicture { get; set; }

        public DateTime? RegistredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}