namespace GameStore.App.Models.Users
{
    using GameStore.App.Infrastructure.Validation.Users;

    public class RegisterModel
    {
        [Email]
        public string Email { get; set; }

        public string Name { get; set; }

        [Password]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}