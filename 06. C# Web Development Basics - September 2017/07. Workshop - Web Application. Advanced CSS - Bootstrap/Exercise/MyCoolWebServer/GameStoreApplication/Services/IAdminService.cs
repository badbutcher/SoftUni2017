namespace MyCoolWebServer.GameStoreApplication.Services
{
    using System;
    using System.Collections.Generic;
    using MyCoolWebServer.GameStoreApplication.Data.Models;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;

    public interface IAdminService
    {
        void Add(string title, string description, string image, decimal price, double size, string videoId, DateTime releaseDate);

        List<AllGamesViewModel> GetAll();

        Game GetGameById(int id);

        void DeleteGameById(int id);

        void EditGameById(int id, string title, string description, string image, decimal price, double size, string videoId, DateTime releaseDate);
    }
}