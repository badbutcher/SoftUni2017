namespace _004.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using _004.Models.ManyToMany;

    public class Course
    {
        public Course()
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