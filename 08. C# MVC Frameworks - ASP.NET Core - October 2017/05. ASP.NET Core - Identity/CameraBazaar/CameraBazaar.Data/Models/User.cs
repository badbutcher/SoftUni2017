namespace CameraBazaar.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public DateTime LastLoginTime { get; set; }

        public List<Camera> Cameras { get; set; } = new List<Camera>();
    }
}