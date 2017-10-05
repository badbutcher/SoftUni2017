namespace HandMadeHttpServer.Application.Views
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using HandMadeHttpServer.Server.Contracts;

    public class AddCakesView : IView
    {
        public string View()
        {
            StringBuilder sb = new StringBuilder();
            var path = File.ReadAllLines(@"Application\Resources\BuyCakePage.html");
            foreach (var line in path)
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }
    }
}