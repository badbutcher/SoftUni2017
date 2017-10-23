namespace SimpleMvc.Domain.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public IList<Note> Notes { get; set; } = new List<Note>();
    }
}