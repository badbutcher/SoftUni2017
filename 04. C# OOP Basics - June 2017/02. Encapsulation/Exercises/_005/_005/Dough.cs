namespace _005
{
    using System;

    public class Dough
    {
        private string flour;
        private string technique;
        private decimal weight;
        private decimal calories;

        public Dough()
        {
        }

        public Dough(string flour, string technique, decimal weight)
        {
            this.Flour = flour;
            this.Technique = technique;
            this.Weight = weight;
            this.Calories = GetCalories();
        }

        public string Flour
        {
            get
            {
                return this.flour;
            }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flour = value;
            }
        }

        public string Technique
        {
            get
            {
                return this.technique;
            }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.technique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
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
            decimal flour = 0;
            decimal technique = 0;
            switch (Flour.ToLower())
            {
                case "white":
                    flour = 1.5m;
                    break;

                case "wholegrain":
                    flour = 1.0m;
                    break;

                default:
                    break;
            }

            switch (Technique.ToLower())
            {
                case "crispy":
                    technique = 0.9m;
                    break;

                case "chewy":
                    technique = 1.1m;
                    break;

                case "homemade":
                    technique = 1.0m;
                    break;

                default:
                    break;
            }

            calories = (2 * Weight) * flour * technique;
            return calories;
        }
    }
}