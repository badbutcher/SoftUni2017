using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop
{
    class Startup
    {
        static void Main(string[] args)
        {
            ShopContext context = new ShopContext();
            context.Database.Initialize(true);
        }
    }
}
