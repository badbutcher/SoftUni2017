using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Lifecycle.Order
{
    public class OrderAttribute : Attribute
    {
        public long Order { get; set; }

        public OrderAttribute(long order)
        {
            this.Order = order;
        }
    }
}
