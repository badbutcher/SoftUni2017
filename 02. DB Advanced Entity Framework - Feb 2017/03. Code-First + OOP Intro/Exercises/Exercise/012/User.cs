namespace _012
{
    using System;

    public partial class User
    {
        public int id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        public int? Age { get; set; }

        public bool? IsDeleted { get; set; }
    }
}