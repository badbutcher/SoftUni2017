using Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportXml
{
    class Startup
    {
        private const string BenuesPath = "../../Xmls/venues.xml";

        static void Main()
        {
            ExamContext context = new ExamContext();

            ImportVenues(context);
        }

        private static void ImportVenues(ExamContext context)
        {
            throw new NotImplementedException();
        }
    }
}
