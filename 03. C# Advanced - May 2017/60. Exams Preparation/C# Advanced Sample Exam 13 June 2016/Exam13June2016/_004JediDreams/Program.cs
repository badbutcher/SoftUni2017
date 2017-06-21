using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _004JediDreams
{
    class Program
    {
        static void Main()
        {
            string getMetodsPattern = @"static\s.*?\s(.*?)\((.*?)\)";
            Regex regex = new Regex(getMetodsPattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                Match matchMetod = regex.Match(text);

                if (matchMetod.Success)
                {
                    Console.WriteLine(matchMetod.Groups[1].Value);
                    Console.WriteLine(matchMetod.Groups[2].Value);
                }
            }
        }
    }
}