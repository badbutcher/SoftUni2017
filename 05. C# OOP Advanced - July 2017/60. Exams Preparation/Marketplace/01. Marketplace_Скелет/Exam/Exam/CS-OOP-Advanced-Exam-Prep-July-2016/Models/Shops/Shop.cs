using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    public abstract class Shop : IShop
    {
        private readonly IList<IProduct> products;
        private readonly IShop successor;
        private readonly int capacity;
        private int usedCapacity;

        protected Shop(IShop successor, int capacity)
        {
            this.capacity = capacity;
            this.successor = successor;
            this.usedCapacity = 0;
            this.products = new List<IProduct>();
        }


        public IEnumerable<IProduct> Products
        {
            get
            {
                return this.products;
            }
        }

        public IShop AddProduct(IProduct product)
        {
            if (product.Size + this.usedCapacity > this.capacity
                && this.successor != null)
            {
                return this.successor.AddProduct(product);
            }

            this.usedCapacity += product.Size;
            this.products.Add(product);

            return this;
        }
    }
}
