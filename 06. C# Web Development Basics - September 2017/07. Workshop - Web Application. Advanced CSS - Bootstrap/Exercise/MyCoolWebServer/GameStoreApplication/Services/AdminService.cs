using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCoolWebServer.GameStoreApplication.Data;
using MyCoolWebServer.GameStoreApplication.Data.Models;
using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;

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

        public List<AllGamesViewModel> GetAll()
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                var allGames = db
                    .Games.Select(a => new AllGamesViewModel
                    {
                        Id = a.Id,
                        Name = a.Title,
                        Size = a.Size,
                        Price = a.Price
                    }).ToList();

                return allGames;
            }
        }

        public Game GetGameById(int id)
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                var game = db
                    .Games.FirstOrDefault(a => a.Id == id);

                return game;
            }
        }

        public void DeleteGameById(int id)
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                var game = db
                    .Games.FirstOrDefault(a => a.Id == id);

                db.Remove(game);
                db.SaveChanges();
            }
        }

        public void EditGameById(int id, string title, string description, string image, decimal price, double size, string videoId, DateTime releaseDate)
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                var game = db
                    .Games.FirstOrDefault(a => a.Id == id);

                game.Title = title;
                game.Description = description;
                game.Image = image;
                game.Price = price;
                game.Size = size;
                game.VideoId = videoId;
                game.ReleaseDate = releaseDate;

                db.Update(game);
                db.SaveChanges();
            }
        }
    }
}
