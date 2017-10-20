namespace MyCoolWebServer.GameStoreApplication.Services
{
    using System.Collections.Generic;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Home;

    public interface IHomeSerice
    {
        IEnumerable<HomeGameInfoViewModel> GetAllGames();
    }
}