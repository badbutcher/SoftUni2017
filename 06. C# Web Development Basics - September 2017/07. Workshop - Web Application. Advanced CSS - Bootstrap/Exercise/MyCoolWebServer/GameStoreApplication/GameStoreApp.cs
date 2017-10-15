namespace MyCoolWebServer.GameStoreApplication
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using MyCoolWebServer.GameStoreApplication.Data;
    using MyCoolWebServer.Server.Contracts;
    using MyCoolWebServer.Server.Routing.Contracts;

    public class GameStoreApp : IApplication
    {
        public void InitializeDatabase()
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                db.Database.Migrate();
            }
        }

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            throw new NotImplementedException();
        }
    }
}