namespace Exam.App.Models.Users
{
    using Exam.App.Infrastructure.Validation;
    using Exam.App.Infrastructure.Validation.Users;

    public class RegisterModel
    {
        [Required]
        [Email]
        public string Email { get; set; }

        public string FullName { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}