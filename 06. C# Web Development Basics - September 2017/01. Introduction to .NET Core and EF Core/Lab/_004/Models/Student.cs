namespace _004.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using _004.Models.ManyToMany;

    public class Student
    {
        public Student()
        {
            this.StudentsCourses = new HashSet<StudentsCourses>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<StudentsCourses> StudentsCourses { get; set; }
    }
}