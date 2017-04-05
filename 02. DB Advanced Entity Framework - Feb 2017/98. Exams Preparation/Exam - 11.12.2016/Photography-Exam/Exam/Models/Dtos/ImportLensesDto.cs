using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Dtos
{
    public class ImportLensesDto
    {
        public string Make { get; set; }

        public int LocalLength { get; set; }

        public float MaxAperture { get; set; }

        public string CompatibleWith { get; set; }
    }
}
