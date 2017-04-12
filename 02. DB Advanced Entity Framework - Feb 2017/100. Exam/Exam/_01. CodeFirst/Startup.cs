using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CodeFirst
{
    class Startup
    {
        static void Main()
        {
            ExamContext context = new ExamContext();
            context.Database.Initialize(true);
        }
    }
}