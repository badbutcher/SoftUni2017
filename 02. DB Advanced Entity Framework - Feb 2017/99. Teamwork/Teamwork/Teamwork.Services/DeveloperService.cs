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
    public class DeveloperService
    {
        public void GreateDeveloper(string name, string countryName, string cityName, DateTime founded)
        {
            Developer Developer = new Developer
            {
                Name = name,
                FoundedInCountryName = countryName,
                FoundedInCityName = cityName,
                DateFounded = founded
            };

            using (TeamworkContext context = new TeamworkContext())
            {
                context.Developers.Add(Developer);
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