using System.Collections.Generic;

namespace _011.Models
{
    public class Continent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CountriesContinents> Countries { get; set; } = new List<CountriesContinents>();
    }
}