namespace _011
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> result = new List<string>();
            foreach (var item in input)
            {
                var revered = new string(item.Reverse().ToArray());
                if (item == revered)
                {
                    result.Add(item);
                }
            }

            var res = result.OrderBy(x => x).Distinct();
            Console.WriteLine("[" + string.Join(", ", res) + "]");
        }
    }
}