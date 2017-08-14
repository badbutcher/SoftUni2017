using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products
{
    public interface IProduct
    {
        int Id { get; }

        string Name { get; set; }

        int Size { get; set; }

        IShop Shop { get; set; }
    }
}
