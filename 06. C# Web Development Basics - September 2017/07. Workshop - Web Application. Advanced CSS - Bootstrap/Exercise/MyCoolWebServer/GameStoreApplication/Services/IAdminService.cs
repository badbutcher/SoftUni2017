using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolWebServer.GameStoreApplication.Services
{
    public interface IAdminService
    {
        void Add(string title, string description, string image, decimal price, double size, string videoId, DateTime releaseDate);
    }
}
