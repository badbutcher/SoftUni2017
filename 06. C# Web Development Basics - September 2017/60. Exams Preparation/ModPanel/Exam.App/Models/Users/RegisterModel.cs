namespace Exam.App.Models.Users
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Exam.App.Data.Model;
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