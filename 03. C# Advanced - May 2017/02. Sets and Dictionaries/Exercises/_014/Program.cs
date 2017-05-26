namespace _014
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<int>>> dragons = new Dictionary<string, Dictionary<string, List<int>>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string type = input[0];
                string name = input[1];
                int damage = 0;
                int health = 0;
                int armor = 0;

                FixValues(input, out damage, out health, out armor);

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new Dictionary<string, List<int>>());
                }

                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type][name] = new List<int>();
                }

                dragons[type][name].Clear();
                dragons[type][name].Add(damage);
                dragons[type][name].Add(health);
                dragons[type][name].Add(armor);
            }

            foreach (var type in dragons)
            {
                var average = GetAverage(type.Value);

                Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})", type.Key, average[0], average[1], average[2]);

                foreach (var item in type.Value.OrderBy(a => a.Key))
                {
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}", item.Key, item.Value[0], item.Value[1], item.Value[2]);
                }
            }
        }

        private static List<double> GetAverage(Dictionary<string, List<int>> value)
        {
            double divider = value.Count;

            double totalDamage = 0;
            double totalHealth = 0;
            double totalArmor = 0;

            foreach (var item in value)
            {
                totalHealth += item.Value[0];
                totalDamage += item.Value[1];
                totalArmor += item.Value[2];
            }

            List<double> result = new List<double>();
            result.Add(totalHealth / divider);
            result.Add(totalDamage / divider);
            result.Add(totalArmor / divider);

            return result;
        }

        private static void FixValues(string[] input, out int damage, out int health, out int armor)
        {
            if (input[2] == "null")
            {
                damage = 45;
            }
            else
            {
                damage = int.Parse(input[2]);
            }

            if (input[3] == "null")
            {
                health = 250;
            }
            else
            {
                health = int.Parse(input[3]);
            }

            if (input[4] == "null")
            {
                armor = 10;
            }
            else
            {
                armor = int.Parse(input[4]);
            }
        }
    }
}