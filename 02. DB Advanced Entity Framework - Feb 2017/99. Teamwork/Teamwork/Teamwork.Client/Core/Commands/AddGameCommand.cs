using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Models.Enums;

namespace Teamwork.Client.Core.Commands
{
    public class AddGameCommand
    {
        public string Execute(string[] data)
        {
            string name = data[0];
            bool isSingleplayer = bool.Parse(data[1]);
            bool isMultiplayer = bool.Parse(data[2]);
            DateTime relaseDate = DateTime.Parse(data[3]);
            string gameGender = data[4];

            return "asd";
        }
    }
}
