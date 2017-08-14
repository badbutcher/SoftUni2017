using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products;
using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Provider.Data
{
    public interface IDataProvider
    {
        IProduct AddProduct(int size, string name, string type);

        IEnumerable<IProduct> GetProductsBySizeNameType(int size, string name, string type);

        IEnumerable<IProduct> GetProductsBySizeName(int size, string name);

        IProduct GetProductById(int id);

        IProduct EditProduct(int id, int newSize, string newName);

        IShop AddProductToShop(string shopType, int productId);

        IEnumerable<IProduct> GetProductByShop(string shopType);
    }
}
