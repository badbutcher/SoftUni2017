using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Client.Core.Commands;
using Teamwork.Services;

namespace Teamwork.Client.Core
{
    public class CommandDispatcher
    {
        public string DispatchCommand(string commandParameters)
        {
            GameService gameService = new GameService();

            string result = string.Empty;

            switch (commandParameters)
            {
                case "AddGame":
                    AddGameCommand addGame = new AddGameCommand(gameService);
                    result = addGame.Execute(commandParameters);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
//public string DispatchCommand(string[] commandParameters)
//{
//    GameService gameService = new GameService();

//    string commandName = commandParameters[0];
//    commandParameters = commandParameters.Skip(1).ToArray();
//    string result = string.Empty;

//    switch (commandName)
//    {
//        case "AddGame":
//            AddGameCommand addGame = new AddGameCommand(gameService);
//            result = addGame.Execute(commandParameters);
//            break;
//        default:
//            break;
//    }

//    return result;
//}