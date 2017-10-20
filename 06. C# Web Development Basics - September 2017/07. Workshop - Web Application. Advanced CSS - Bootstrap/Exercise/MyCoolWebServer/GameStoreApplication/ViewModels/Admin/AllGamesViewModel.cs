namespace MyCoolWebServer.GameStoreApplication.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AllGamesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }
    }
}