using Exam.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    [Table("Gifts")]
    public class Gift : Present
    {
        public string Name { get; set; }

        public GiftSize Size { get; set; }
    }
}