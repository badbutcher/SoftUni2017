using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    public interface IShop
    {
        IEnumerable<IProduct> Products { get; }

        IShop AddProduct(IProduct product);
    }
}