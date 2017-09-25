namespace _011.Models
{
    public class CountriesContinents
    {
        public string CountrieId { get; set; }

        public Countrie Countrie { get; set; }

        public int ContinentId { get; set; }

        public Continent Continent { get; set; }
    }
}