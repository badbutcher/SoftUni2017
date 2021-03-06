﻿namespace MyCoolWebServer.GameStoreApplication.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using MyCoolWebServer.GameStoreApplication.Data;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Home;

    public class HomeService : IHomeSerice
    {
        public List<HomeGameInfoViewModel> GetAllGames()
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