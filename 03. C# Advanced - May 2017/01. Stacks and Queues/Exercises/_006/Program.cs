namespace _006
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int startFrom = 0;
            int petrolLeft = 0;

            for (int i = 0; i < n; i++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int petrol = data[0];
                int distance = data[1];

                petrolLeft += petrol;

                if (petrolLeft >= distance)
                {
                    petrolLeft -= distance;
                }
                else
                {
                    startFrom = i + 1;
                    petrolLeft = 0;
                }
            }

            Console.WriteLine(startFrom);
        }
    }
}