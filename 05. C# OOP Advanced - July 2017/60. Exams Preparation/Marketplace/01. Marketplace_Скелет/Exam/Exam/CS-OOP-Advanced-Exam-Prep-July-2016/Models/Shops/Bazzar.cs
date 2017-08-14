using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Lifecycle.Order;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    [Order(2)]
    public class Bazzar : Shop
    {
        private const int Capacity = 30;

        public Bazzar(IShop successor) : base(successor, Capacity)
        {
        }
    }
}
