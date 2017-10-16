using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolWebServer.GameStoreApplication.Services
{
    public interface IUserService
    {
        bool Create(string email, string name, string password);

        bool Find(string email, string password);
    }
}