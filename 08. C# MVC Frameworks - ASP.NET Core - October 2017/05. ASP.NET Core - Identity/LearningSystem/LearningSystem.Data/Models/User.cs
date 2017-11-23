namespace LearningSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(DataConstants.UserNameMinLenght)]
        [MaxLength(DataConstants.UserNameMaxLenght)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();

        public List<Course> Trainings { get; set; } = new List<Course>();

        public List<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
    }
}