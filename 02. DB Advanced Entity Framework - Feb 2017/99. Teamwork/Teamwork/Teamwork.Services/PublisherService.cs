using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Data;
using Teamwork.Models;
using Teamwork.Models.Enums;

namespace Teamwork.Services
{
    public class PublisherService
    {
        public void GreatePublisher(string name, string countryName, string cityName, DateTime founded)
        {
            Publisher Publisher = new Publisher
            {
                Name = name,
                FoundedInCountryName = countryName,
                FoundedInCityName = cityName,
                FoundedIn = founded
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                context.Publishers.Add(Publisher);
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