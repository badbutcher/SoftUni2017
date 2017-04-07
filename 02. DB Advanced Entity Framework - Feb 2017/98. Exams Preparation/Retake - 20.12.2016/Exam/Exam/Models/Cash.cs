using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    [Table("Cash")]
    public class Cash : Present
    {
        public float CashAmount { get; set; }
    }
}