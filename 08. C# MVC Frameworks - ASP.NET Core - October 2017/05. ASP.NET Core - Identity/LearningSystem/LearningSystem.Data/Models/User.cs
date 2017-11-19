namespace LearningSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public IEnumerable<Article> Articles { get; set; } = new List<Article>();

        public IEnumerable<UserCourse> Courses { get; set; } = new List<UserCourse>();
    }
}