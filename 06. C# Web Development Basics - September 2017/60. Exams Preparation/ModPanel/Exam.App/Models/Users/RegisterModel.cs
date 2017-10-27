namespace Exam.App.Models.Users
{
    using Exam.App.Infrastructure.Users;
    using Exam.App.Infrastructure.Validation;

    public class RegisterModel
    {
        [Required]
        [Email]
        public string Email { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        public int Position { get; set; }
    }
}