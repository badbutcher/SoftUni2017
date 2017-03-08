namespace _01Do04.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;
    using System.Collections.Generic;

    [Table("Resources")]
    public class Resources
    {
        public Resources()
        {
            Licenses = new HashSet<License>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public TypeOfResource Type { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}