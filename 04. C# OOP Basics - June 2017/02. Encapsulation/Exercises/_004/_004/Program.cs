namespace _004
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                int countPeople = 0;
                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }
                    else
                    {
                        if (countPeople == 0)
                        {
                            countPeople++;
                            string[] data = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var item in data)
                            {
                                string[] token = item.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                                string name = token[0];
                                decimal money = decimal.Parse(token[1]);
                                people.Add(new Person(name, money, new List<Product>()));
                            }
                        }
                        else if (countPeople == 1)
                        {
                            countPeople++;
                            string[] data = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var item in data)
                            {
                                string[] token = item.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                                string product = token[0];
                                decimal price = decimal.Parse(token[1]);
                                products.Add(new Product(product, price));
                            }
                        }
                        else
                        {
                            string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string name = data[0];
                            string product = data[1];
                            Person nameFind = people.First(a => a.Name == name);
                            Product productFind = products.First(a => a.Name == product);

                            if (nameFind.Money >= productFind.Cost)
                            {
                                nameFind.Money -= productFind.Cost;
                                nameFind.Products.Add(productFind);
                                Console.WriteLine("{0} bought {1}", name, product);
                            }
                            else
                            {
                                Console.WriteLine("{0} can't afford {1}", name, product);
                            }
                        }
                    }
                }

                foreach (var person in people)
                {
                    if (person.Products.Count > 0)
                    {
                        Console.WriteLine("{0} - {1}", person.Name, string.Join(", ", person.Products.Select(a => a.Name)));
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
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