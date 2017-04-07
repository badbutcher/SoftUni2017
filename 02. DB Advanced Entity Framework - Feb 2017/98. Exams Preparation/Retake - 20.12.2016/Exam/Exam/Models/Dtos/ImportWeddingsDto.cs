using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Dtos
{
    public class ImportWeddingsDto
    {
        public string Bride { get; set; }

        public string Bridegroom { get; set; }

        public DateTime Date { get; set; }

        public string Agency { get; set; }

        public Person[] Guests { get; set; }
    }
}
