using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005
{
    public class Program
    {
        public static void Main()
        {
            try
            {

                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }
                    else
                    {
                        string[] data = input.Split();

                        if (data[0] == "Dough")
                        {
                            string flour = data[1];
                            string technique = data[2];
                            decimal weight = decimal.Parse(data[3]);
                            Dough dough = new Dough(flour, technique, weight);
                            Console.WriteLine("{0:F2}", dough.Calories);
                        }
                        else if (data[0] == "Topping")
                        {
                            string type = data[1];
                            decimal weight = decimal.Parse(data[2]);
                            Topping topping = new Topping(type, weight);
                            Console.WriteLine("{0:F2}", topping.Calories);
                        }
                        else
                        {
                            int toppingsCount = int.Parse(data[2]);
                            Pizza pizza = new Pizza(data[1], 0, new Dough(), new List<Topping>());

                            if (toppingsCount > 10)
                            {
                                Console.WriteLine("Number of toppings should be in range [0..10].");
                                break;
                            }

                            string[] doughData = Console.ReadLine().Split();
                            string flour = doughData[1];
                            string technique = doughData[2];
                            decimal weight = decimal.Parse(doughData[3]);
                            Dough dough = new Dough(flour, technique, weight);
                            pizza = new Pizza(pizza.Name, 0, dough, new List<Topping>());

                            for (int i = 0; i < toppingsCount; i++)
                            {
                                string[] pizzaData = Console.ReadLine().Split();
                                string type = pizzaData[1];
                                decimal w = decimal.Parse(pizzaData[2]);
                                Topping topping = new Topping(type, w);
                                pizza.Toppings.Add(topping);
                            }

                            decimal toppingsCalories = pizza.Toppings.Select(a => a.Calories).Sum();
                            Console.WriteLine("{0} - {1:F2} Calories.", pizza.Name, pizza.Dough.Calories + toppingsCalories);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}