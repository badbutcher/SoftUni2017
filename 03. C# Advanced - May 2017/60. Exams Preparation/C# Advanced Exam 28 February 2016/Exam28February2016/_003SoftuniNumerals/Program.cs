using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _003SoftuniNumerals
{
    class Program
    {
        static void Main()
        {
            string pattern = "(aa)|(aba)|(bcc)|(cc)|(cdc)";
            Regex regex = new Regex(pattern);
            string numberString = string.Empty;

            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);

            foreach (Match item in matches)
            {
                if (item.Value == "aa")
                {
                    numberString += "0";
                }
                else if (item.Value == "aba")
                {
                    numberString += "1";
                }
                else if (item.Value == "bcc")
                {
                    numberString += "2";
                }
                else if (item.Value == "cc")
                {
                    numberString += "3";
                }
                else if (item.Value == "cdc")
                {
                    numberString += "4";
                }
            }

            double result = 0;

            for (int i = 0; i < numberString.Length; i++)
            {
                double digit = numberString[numberString.Length - 1 - i] - '0';
                result += digit * Math.Pow(5, i);
            }


            Console.WriteLine(result);
        }
    }
}