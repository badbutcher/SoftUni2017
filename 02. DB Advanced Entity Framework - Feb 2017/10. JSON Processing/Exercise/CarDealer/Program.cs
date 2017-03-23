using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    class Program
    {
        static void Main(string[] args)
        {
            CarContext context = new CarContext();
            context.Database.Initialize(true);
        }
    }
}
