using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Lifecycle.Order;
using CS_OOP_Advanced_Exam_Prep_July_2016.Lifecycle.Component;
using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products;
using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops;
using CS_OOP_Advanced_Exam_Prep_July_2016.Provider.Types;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Provider.Data
{
    public class MarketDataProvider : IDataProvider
    {
        private readonly IDictionary<int, IProduct> productById;

        private readonly IDictionary<int, IDictionary<string, IDictionary<string, ISet<IProduct>>>>
            productsBySizeNameType;

        private readonly IDictionary<int, IDictionary<string, ISet<IProduct>>>
           productsBySizeName;

        private readonly IDictionary<string, IShop> shops;

        [Inject]
        private ITypeProvider typeProvider;

        public MarketDataProvider()
        {
            this.productById = new Dictionary<int, IProduct>();
            this.productsBySizeName = new Dictionary<int, IDictionary<string, ISet<IProduct>>>();
            this.productsBySizeNameType = new Dictionary<int, IDictionary<string, IDictionary<string, ISet<IProduct>>>>();
            this.shops = new Dictionary<string, IShop>();
        }

        public IProduct AddProduct(int size, string name, string type)
        {
            throw new NotImplementedException();
        }

        public IShop AddProductToShop(string shopType, int productId)
        {
            throw new NotImplementedException();
        }

        public IProduct EditProduct(int id, int newSize, string newName)
        {
            throw new NotImplementedException();
        }

        public IProduct GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> GetProductByShop(string shopType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> GetProductsBySizeName(int size, string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> GetProductsBySizeNameType(int size, string name, string type)
        {
            throw new NotImplementedException();
        }

        private void Initialize()
        {
            IEnumerable<Type> shopTypes
                = this.typeProvider.GetClassesByAttribute(typeof(OrderAttribute))
                    .Where(c => typeof(IShop).IsAssignableFrom(c))
                    .OrderBy(c => c.GetCustomAttribute<OrderAttribute>().Order);

            IShop successor = null;

            foreach (Type shopType in shopTypes)
            {
                IShop shop = (IShop)Activator.CreateInstance(shopType, successor);
                this.shops.Add(shopType.Name, shop);
                successor = shop;
            }
        }
    }
}
