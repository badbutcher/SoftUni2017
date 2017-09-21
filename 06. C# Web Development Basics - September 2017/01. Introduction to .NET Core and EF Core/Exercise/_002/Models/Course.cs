namespace _002.Models
{
    using System;
    using System.Collections.Generic;
    using _002.Models.ManyToMany;

    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<StudentsCourses> Students { get; set; } = new List<StudentsCourses>();

        public ICollection<Resource> Resources { get; set; } = new List<Resource>();

        public ICollection<Homework> Homework { get; set; } = new List<Homework>();
    }
}