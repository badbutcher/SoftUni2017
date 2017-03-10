namespace _01Do04.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Enums;

    [Table("Resources")]
    public class Resources
    {
        public Resources()
        {
            this.Licenses = new HashSet<License>();
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