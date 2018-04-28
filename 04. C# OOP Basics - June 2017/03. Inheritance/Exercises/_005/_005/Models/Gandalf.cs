namespace _005.Models
{
    using _005.Foods;
    using System.Collections.Generic;
    using System.Linq;

    public class Gandalf
    {
        public Gandalf()
        {
            this.FoodEaten = new List<Food>();
        }

        public List<Food> FoodEaten { get; private set; }

        public void Eat(Food food)
        {
            this.FoodEaten.Add(food);
        }

        public int GetHapinessPoints()
        {
            return FoodEaten.Sum(f => f.GetHapinessPoints());
        }
    }
}