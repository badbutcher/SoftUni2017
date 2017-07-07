using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                else
                {
                    string[] animalData = input.Split();
                    string animalType = animalData[0];

                    string[] foodData = Console.ReadLine().Split();
                    Food food = MakeFood(foodData);

                    if (animalType == "Cat")
                    {
                        Animal cat = new Cat(animalData[0], animalData[1], double.Parse(animalData[2]), 0, animalData[3], animalData[4]);

                        if (cat.Eat(food))
                        {
                            cat.MakeSound();
                        }
                    }
                }
            }
        }

        private static Food MakeFood(string[] foodData)
        {
            string foodType = foodData[0];
            int quantity = int.Parse(foodData[1]);

            if (foodType == "Meat")
            {
                return new Meat(quantity);
            }
            else
            {
                return new Vegetable(quantity);
            }
        }
    }
}