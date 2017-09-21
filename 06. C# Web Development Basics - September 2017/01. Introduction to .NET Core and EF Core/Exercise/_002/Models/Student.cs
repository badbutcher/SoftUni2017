namespace _002.Models
{
    using System;
    using System.Collections.Generic;
    using _002.Models.ManyToMany;

    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistratedOn { get; set; }

        public DateTime BirthDay { get; set; }

        public ICollection<StudentsCourses> Courses { get; set; } = new List<StudentsCourses>();

        public ICollection<Homework> Homework { get; set; } = new List<Homework>();
    }
}