namespace _003.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using _003.Models.Enums;

    public class Resource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ResourseType ResourseType { get; set; }

        [Required]
        public string Url { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<License> Licenses { get; set; } = new List<License>();
    }
}