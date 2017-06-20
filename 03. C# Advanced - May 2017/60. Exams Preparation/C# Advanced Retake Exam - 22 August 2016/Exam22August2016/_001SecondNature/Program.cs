namespace _001SecondNature
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Queue<int> flowers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> buckets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            List<int> secondNature = new List<int>();
            while (flowers.Count != 0 && buckets.Count != 0)
            {
                int flower = flowers.Dequeue();
                int bucket = buckets.Pop();

                if (bucket > flower)
                {
                    bucket -= flower;
                    bucket += buckets.Pop();
                    buckets.Push(bucket);
                }
                else if (bucket - flower == 0)
                {
                    secondNature.Add(flower);
                }
                else
                {
                    while (bucket < flower && flowers.Count != 0 && buckets.Count != 0)
                    {
                        bucket += buckets.Pop();
                        bucket -= flower;
                    }

                    if (buckets.Count != 0)
                    {
                        bucket += buckets.Pop();
                        buckets.Push(bucket);
                    }

                    bucket -= flower;
                }
            }

            if (flowers.Count == 0)
            {
                Console.WriteLine(string.Join(" ", buckets));
            }
            else
            {
                Console.WriteLine(string.Join(" ", flowers));
            }

            if (secondNature.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine(string.Join(" ", secondNature));
            }
        }
    }
}