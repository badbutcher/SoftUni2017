using System;
using System.Collections.Generic;
using System.Text;
using HandMadeHttpServer.Server;
using HandMadeHttpServer.Server.Contracts;

namespace HandMadeHttpServer.Application.Views
{
    public class CakeDetails : IView
    {
        private readonly Model cake;

        public CakeDetails(Model cake)
        {
            this.cake = cake;
        }

        public string View()
        {
            return $"<body>name: {cake["name"]}</br></body>";
        }
    }
}