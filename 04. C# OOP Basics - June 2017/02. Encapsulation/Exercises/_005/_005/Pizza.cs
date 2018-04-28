namespace _005
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private string name;
        private decimal totalCalories;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, decimal totalCalories, Dough dough, List<Topping> toppings)
        {
            this.Name = name;
            this.TotalCalories = totalCalories;
            this.Dough = dough;
            this.Toppings = toppings;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public decimal TotalCalories
        {
            get
            {
                return this.totalCalories;
            }
            private set
            {
                this.totalCalories = value;
            }
        }

        public Dough Dough
        {
            get
            {
                return this.dough;
            }
            private set
            {
                this.dough = value;
            }
        }

        public List<Topping> Toppings
        {
            get
            {
                return this.toppings;
            }
            private set
            {
                if (value.Count > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                this.toppings = value;
            }
        }

        public void AddToppings(Topping topping)
        {
            toppings.Add(topping);
        }
    }
}