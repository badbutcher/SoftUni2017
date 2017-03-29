namespace Teamwork.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int? ReviewId { get; set; }

        public virtual Review Review { get; set; }
    }
}