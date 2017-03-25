using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamwork.Client.Core.Commands
{
    public class ExitCommand
    {
        public string Execute()
        {
            Environment.Exit(0);
            return "bb";
        }
    }
}
