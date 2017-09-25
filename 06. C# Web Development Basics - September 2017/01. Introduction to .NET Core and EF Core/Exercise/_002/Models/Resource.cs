namespace _002.Models
{
    using System.ComponentModel.DataAnnotations;
    using _002.Models.Enums;

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
    }
}