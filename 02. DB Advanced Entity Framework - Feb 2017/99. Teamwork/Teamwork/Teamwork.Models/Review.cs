namespace Teamwork.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public Review()
        {
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Range(1, 10)]
        public float Rating { get; set; }

        public int? GameId { get; set; }

        public virtual Game Game { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}