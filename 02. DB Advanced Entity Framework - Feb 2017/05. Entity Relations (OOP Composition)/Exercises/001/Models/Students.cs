namespace _01Do04.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Students")]
    public class Students
    {
        public Students()
        {
            this.Homework = new List<Homework>();
            this.Courses = new List<Courses>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime? RegistrationDate { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }

        public virtual ICollection<Homework> Homework { get; set; }
    }
}