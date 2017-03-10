namespace _01Do04.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    [Table("Homework")]
    public class Homework
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public HomeworkContentType ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public virtual Students Student { get; set; }
    }
}