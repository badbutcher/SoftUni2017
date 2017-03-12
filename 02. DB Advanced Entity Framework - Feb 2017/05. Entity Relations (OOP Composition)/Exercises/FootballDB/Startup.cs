using FootballDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB
{
    class Startup
    {
        static void Main(string[] args)
        {
            FootballContext context = new FootballContext();
            context.Database.Initialize(true);
            //Console.WriteLine(context.Users.Count());
        }
    }
}
