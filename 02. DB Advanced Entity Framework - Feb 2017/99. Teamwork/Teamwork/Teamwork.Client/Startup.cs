using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamwork.Client.Core;
using Teamwork.Client.Core.Commands;
using Teamwork.Data;
using Teamwork.Models;

namespace Teamwork.Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            //TeamworkContext context = new TeamworkContext();
            //context.Database.Initialize(true);

            CommandDispatcher commandDispatcher = new CommandDispatcher();
            Engine engine = new Engine(commandDispatcher);
            engine.Run();
        }
    }
}
