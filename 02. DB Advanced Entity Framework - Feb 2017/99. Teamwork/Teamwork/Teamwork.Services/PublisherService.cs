namespace Teamwork.Services
{
    using System;
    using System.Linq;
    using Data;
    using Models;

    public class PublisherService
    {
        public void GreatePublisher(string name, string countryName, string cityName, DateTime founded)
        {
            Publisher publisher = new Publisher
            {
                Name = name,
                FoundedInCountryName = countryName,
                FoundedInCityName = cityName,
                FoundedIn = founded
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                context.Publishers.Add(publisher);
                context.SaveChanges();
            }
        }

        public bool DoesPublisherExist(string name)
        {
            using (TeamworkContext context = new TeamworkContext())
            {
                var check = context.Publishers.Any(g => g.Name == name);
                return check;
            }
        }
    }
}