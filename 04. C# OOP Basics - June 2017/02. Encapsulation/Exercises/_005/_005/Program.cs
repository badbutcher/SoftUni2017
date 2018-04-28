namespace _005
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            try
            {
                bool finish = false;
                while (!finish)
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
                            //int toppingsCount = int.Parse(data[2]);

                            //if (toppingsCount > 10)
                            //{
                            //    Console.WriteLine("Number of toppings should be in range [0..10].");
                            //    break;
                            //}

                            string[] doughData = Console.ReadLine().Split();
                            string flour = doughData[1];
                            string technique = doughData[2];
                            decimal weight = decimal.Parse(doughData[3]);
                            Dough dough = new Dough(flour, technique, weight);
                            Pizza pizza = new Pizza(data[1], 0, dough, new List<Topping>());
                            int toppingsCount = 0;
                            while (toppingsCount != 10)
                            {
                                string[] pizzaData = Console.ReadLine().Split();
                                if (pizzaData[0] == "END")
                                {
                                    finish = true;
                                    break;
                                }

                                string type = pizzaData[1];
                                decimal w = decimal.Parse(pizzaData[2]);
                                Topping topping = new Topping(type, w);
                                pizza.AddToppings(topping);
                                toppingsCount++;
                            }

                            if (toppingsCount == 10)
                            {
                                Console.WriteLine("Number of toppings should be in range [0..10].");
                                finish = true;
                                break;
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