using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Data;
using MyCoolWebServer.GameStoreApplication.Data.Models;
using MyCoolWebServer.GameStoreApplication.ViewModels.Home;

namespace MyCoolWebServer.GameStoreApplication.Services
{
    public class HomeService : IHomeSerice
    {
        public IEnumerable<HomeGameInfoViewModel> GetAllGames()
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                var allGames = db.Games
                    .Select(a => new HomeGameInfoViewModel
                    {
                        Thumbnail = a.Image,
                        Title = a.Title,
                        Price = a.Price,
                        Size = a.Size,
                        Description = a.Description
                    }).ToList();

                return allGames;
            }
        }
    }
}
