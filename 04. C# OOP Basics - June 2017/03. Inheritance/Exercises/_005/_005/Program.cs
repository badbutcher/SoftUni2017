namespace _005
{
    using System;
    using _005.Foods;
    using _005.Models;

    public class Program
    {
        public static void Main()
        {
            var foodFactory = new FoodFactory();
            var moodFactory = new MoodFactory();
            var gandalf = new Gandalf();

            var inputFood = Console.ReadLine().Split(new char[] { '\t', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var foodStr in inputFood)
            {
                Food food = foodFactory.GetFood(foodStr);
                gandalf.Eat(food);
            }

            var totalHapinessPoints = gandalf.GetHapinessPoints();
            var currentMood = moodFactory.GetMood(totalHapinessPoints);

            Console.WriteLine(totalHapinessPoints);
            Console.WriteLine(currentMood);
        }
    }
}