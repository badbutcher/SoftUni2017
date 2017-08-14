using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops;

namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products
{
    public abstract class Product : IProduct
    {
        protected Product(int id, string name, int size)
        {
            this.Id = id;
            this.Name = name;
            this.Size = size;
            this.Shop = null;
        }

        public int Id { get; }
        public string Name { get; set; }
        public virtual int Size { get; set; }
        public IShop Shop { get; set; }

        public override int GetHashCode()
        {
            return this.Id;
        }

        //public override string ToString()
        //{
        //    return string.Format(Messages.ProductToString,
        //        this.GetType().Name,
        //        this.Id,
        //        this.Size,
        //        this.Name
        //        );
        //}
    }
}
