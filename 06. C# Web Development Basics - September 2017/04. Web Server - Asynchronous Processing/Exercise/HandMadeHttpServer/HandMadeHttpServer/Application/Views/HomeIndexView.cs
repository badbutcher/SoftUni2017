﻿namespace HandMadeHttpServer.Application.Views
{
    using System.IO;
    using System.Text;
    using HandMadeHttpServer.Server.Contracts;

    public class HomeIndexView : IView
    {
        public string View()
        {
            StringBuilder sb = new StringBuilder();
            var path = File.ReadAllLines(@"Application\Resources\ByTheCake.html");
            foreach (var line in path)
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }
    }
}