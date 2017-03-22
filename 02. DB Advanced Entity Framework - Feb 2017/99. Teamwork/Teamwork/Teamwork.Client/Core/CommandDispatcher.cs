using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Client.Core.Commands;

namespace Teamwork.Client.Core
{
    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string commandName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            string result = string.Empty;

            switch (commandName)
            {
                case "AddGame":
                    AddGameCommand addGame = new AddGameCommand();
                    result = addGame.Execute(commandParameters);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
