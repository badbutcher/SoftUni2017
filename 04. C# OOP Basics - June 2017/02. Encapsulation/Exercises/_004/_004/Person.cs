namespace _004
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money, List<Product> products)
        {
            this.Name = name;
            this.Money = money;
            this.Products = products;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }

        public override string ToString()
        {
            if (this.Products.Count > 0)
            {
                var procuts = this.Products.Select(a => a.Name);
                string result = string.Join(", ", procuts);
                return $"{this.Name} - {result}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }
}