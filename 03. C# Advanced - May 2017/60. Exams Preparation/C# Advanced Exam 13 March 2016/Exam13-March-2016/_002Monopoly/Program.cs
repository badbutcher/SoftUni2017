namespace _002Monopoly
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[][] matrix = new char[input[0]][];
            int money = 50;
            int turns = 0;
            int hotels = 0;

            for (int i = 0; i < input[0]; i++)
            {
                matrix[i] = new char[input[1]];
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                string text = Console.ReadLine();

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = text[j];
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                int row = i + 1;
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        int col = j + 1;
                        if (matrix[i][j] == 'H')
                        {
                            hotels++;
                            Console.WriteLine("Bought a hotel for {0}. Total hotels: {1}.", money, hotels);
                            money = 0;
                            turns++;
                        }
                        else if (matrix[i][j] == 'J')
                        {
                            Console.WriteLine("Gone to jail at turn {0}.", turns);
                            turns += 3;
                            money += hotels * 20;
                        }
                        else if (matrix[i][j] == 'S')
                        {
                            int spendMoney = row * col;
                            
                            if (money > 0)
                            {
                                Console.WriteLine("Spent {0} money at the shop.", spendMoney);
                                money -= spendMoney;
                            }
                            else
                            {
                                Console.WriteLine("Spent 0 money at the shop.");
                            }

                            turns++;
                        }
                        else
                        {
                            turns++;
                        }

                        money += hotels * 10;
                    }
                }
                else
                {
                    for (int j = matrix[i].Length - 1; j >= 0; j--)
                    {
                        int col = j + 1;
                        if (matrix[i][j] == 'H')
                        {
                            hotels++;
                            Console.WriteLine("Bought a hotel for {0}. Total hotels: {1}.", money, hotels);
                            money = 0;
                            turns++;
                        }
                        else if (matrix[i][j] == 'J')
                        {
                            Console.WriteLine("Gone to jail at turn {0}.", turns);
                            turns += 3;
                            money += hotels * 20;
                        }
                        else if (matrix[i][j] == 'S')
                        {
                            int spendMoney = row * col;
                            
                            if (money > 0)
                            {
                                Console.WriteLine("Spent {0} money at the shop.", spendMoney);
                                money -= spendMoney;
                            }
                            else
                            {
                                Console.WriteLine("Spent 0 money at the shop.");
                            }

                            turns++;
                        }
                        else
                        {
                            turns++;
                        }

                        money += hotels * 10;
                    }
                }

                if (money < 0)
                {
                    money = 0;
                }
            }

            Console.WriteLine("Turns {0}", turns);
            Console.WriteLine("Money {0}", money);
        }
    }
}