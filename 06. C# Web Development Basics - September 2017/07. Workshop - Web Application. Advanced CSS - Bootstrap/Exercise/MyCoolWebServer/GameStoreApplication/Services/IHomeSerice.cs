namespace MyCoolWebServer.GameStoreApplication.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyCoolWebServer.GameStoreApplication.Data.Models;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Home;

    public interface IHomeSerice
    {
        IEnumerable<HomeGameInfoViewModel> GetAllGames();
    }
}