namespace _011.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Countrie
    {
        [Key]
        [MaxLength(3)]
        [MinLength(3)]
        public string Id { get; set; }

        public string Name { get; set; }

        public List<CountriesContinents> Contienets { get; set; } = new List<CountriesContinents>();
    }
}