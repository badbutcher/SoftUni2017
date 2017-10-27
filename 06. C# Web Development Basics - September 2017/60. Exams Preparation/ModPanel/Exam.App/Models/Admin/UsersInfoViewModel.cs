namespace Exam.App.Models.Admin
{
    using Exam.App.Data.Model;

    public class UsersInfoViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public Position Possiton { get; set; }

        public bool IsAproved { get; set; }

        public int Posts { get; set; }
    }
}