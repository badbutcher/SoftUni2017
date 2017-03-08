namespace _01Do04.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Courses")]
    public class Courses
    {
        public Courses()
        {
            this.Students = new HashSet<Students>();
            this.Homework = new HashSet<Homework>();
            this.Resources = new HashSet<Resources>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Students> Students { get; set; }

        public virtual ICollection<Resources> Resources { get; set; }

        public virtual ICollection<Homework> Homework { get; set; }
    }
}