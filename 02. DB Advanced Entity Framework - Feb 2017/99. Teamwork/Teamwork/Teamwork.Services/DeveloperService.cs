namespace Teamwork.Services
{
    using System;
    using System.Linq;
    using Data;
    using Models;

    public class DeveloperService
    {
        public void GreateDeveloper(string name, string countryName, string cityName, DateTime founded)
        {
            Developer developer = new Developer
            {
                Name = name,
                FoundedInCountryName = countryName,
                FoundedInCityName = cityName,
                DateFounded = founded
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                context.Developers.Add(developer);
                context.SaveChanges();
            }
        }

        public bool DoesDeveloperExist(string name)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Developers.Any(g => g.Name == name);
                return check;
            }
        }
    }
}