namespace _005
{
    using System;

    public class Topping
    {
        private string type;
        private decimal weight;
        private decimal calories;

        public Topping(string type, decimal weight)
        {
            this.Type = type;
            this.Weight = weight;
            this.Calories = GetCalories();
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                string data = value.ToLower();
                if (data != "meat" && data != "veggies" && data != "sauce" && data != "cheese")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public decimal Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public decimal Calories
        {
            get
            {
                return this.calories;
            }
            private set
            {
                this.calories = value;
            }
        }

        private decimal GetCalories()
        {
            decimal calories = 0;
            decimal type = 0;
            switch (Type.ToLower())
            {
                case "meat":
                    type = 1.2m;
                    break;

                case "veggies":
                    type = 0.8m;
                    break;

                case "cheese":
                    type = 1.1m;
                    break;

                case "sauce":
                    type = 0.9m;
                    break;

                default:
                    break;
            }

            calories = (2 * Weight) * type;
            return calories;
        }
    }
}