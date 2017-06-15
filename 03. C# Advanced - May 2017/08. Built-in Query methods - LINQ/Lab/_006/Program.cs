namespace _006
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();

            var result = input.Select(w =>
            {
                long value;
                bool success = long.TryParse(w, out value);
                return new { value, success };
            })
            .Where(b => b.success)
            .Select(x => x.value);

            if (result.Count() != 0)
            {
                Console.WriteLine("{0}", result.Sum());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}