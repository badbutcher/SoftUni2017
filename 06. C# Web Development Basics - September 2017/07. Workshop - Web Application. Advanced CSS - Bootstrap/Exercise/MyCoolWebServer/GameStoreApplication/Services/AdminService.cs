using System;
using System.Collections.Generic;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Data;
using MyCoolWebServer.GameStoreApplication.Data.Models;

namespace MyCoolWebServer.GameStoreApplication.Services
{
    public class AdminService : IAdminService
    {
        public void Add(string title, string description, string image, decimal price, double size, string videoId, DateTime releaseDate)
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                Game game = new Game
                {
                    Title = title,
                    Description = description,
                    Image = image,
                    Price = price,
                    Size = size,
                    VideoId = videoId,
                    ReleaseDate = releaseDate
                };

                db.Add(game);
                db.SaveChanges();
            }
        }
    }
}
