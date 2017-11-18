namespace CameraBazaar.Services.Models.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CameraBazaar.Data.Models;

    public class UserBasicInfoModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public DateTime LastLoginTime { get; set; }

        public IList<Camera> Cameras { get; set; }
    }
}