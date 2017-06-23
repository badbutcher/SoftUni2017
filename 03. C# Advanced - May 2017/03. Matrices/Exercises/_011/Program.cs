namespace _011
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[][] matrix = new int[input[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[input[0]];
            }

            string command = Console.ReadLine();

            while (true)
            {
                if (command == "stop")
                {
                    break;
                }
                else
                {
                    int[] car = command.Split().Select(int.Parse).ToArray();
                    var enterRow = car[0];
                    var carRow = car[1];
                    var carCol = car[2];
                    var isParked = false;

                    for (int col = 1; col < matrix[carRow].Length; col++)
                    {
                        if (matrix[carRow][col] == 0 && col == carCol)
                        {
                            matrix[carRow][col] = 1;
                            var distance = col + 1 + Math.Abs(enterRow - carRow);
                            Console.WriteLine(distance);
                            isParked = true;
                            break;
                        }
                    }

                    if (!isParked)
                    {
                        bool leftAvailable = false;
                        bool rightAvailable = false;
                        var leftDistance = 0;
                        var rightDistance = 0;

                        for (int col = carCol - 1; col > 0; col--)
                        {
                            if (matrix[carRow][col] == 0)
                            {
                                leftDistance++;
                                leftAvailable = true;
                                break;
                            }

                            leftDistance++;
                        }

                        for (int col = carCol + 1; col < matrix[carRow].Length; col++)
                        {
                            if (matrix[carRow][col] == 0)
                            {
                                rightDistance++;
                                rightAvailable = true;
                                break;
                            }

                            rightDistance++;
                        }

                        if (!leftAvailable && !rightAvailable)
                        {
                            Console.WriteLine($"Row {carRow} full");
                        }
                        else
                        {
                            if (leftAvailable && rightAvailable)
                            {
                                if (leftDistance <= rightDistance)
                                {
                                    var distance = (carCol - leftDistance + 1) + Math.Abs(enterRow - carRow);
                                    matrix[carRow][carCol - leftDistance] = 1;
                                    Console.WriteLine(distance);
                                }
                                else
                                {
                                    var distance = carCol + rightDistance + 1 + Math.Abs(enterRow - carRow);
                                    matrix[carRow][carCol + rightDistance] = 1;
                                    Console.WriteLine(distance);
                                }
                            }
                            else if (leftAvailable)
                            {
                                var distance = (carCol - leftDistance + 1) + Math.Abs(enterRow - carRow);
                                matrix[carRow][carCol - leftDistance] = 1;
                                Console.WriteLine(distance);
                            }
                            else
                            {
                                var distance = carCol + rightDistance + 1 + Math.Abs(enterRow - carRow);
                                matrix[carRow][carCol + rightDistance] = 1;
                                Console.WriteLine(distance);
                            }
                        }
                    }
                }
            }
        }
    }
}