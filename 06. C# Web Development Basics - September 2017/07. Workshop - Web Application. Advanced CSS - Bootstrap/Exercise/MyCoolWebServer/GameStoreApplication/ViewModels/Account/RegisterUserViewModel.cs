using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCoolWebServer.GameStoreApplication.ViewModels.Account
{
    public class RegisterUserViewModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}