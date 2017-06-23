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
            //static\s+.+?\s+([a-zA-Z]*[A-Z]{1}[a-zA-Z]*)
            //[A-Z]{1}[a-zA-Z]+\(

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> methods = new Dictionary<string, List<string>>();

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string inputLine = Console.ReadLine();
                text.Append(inputLine);
            }

            Regex methodDeclarationPattern = new Regex(@"static\s+.+?\s+([a-zA-Z]*[A-Z]{1}[a-zA-Z]*)");
            Regex methodCallPattern = new Regex(@"([A-Z]{1}[a-zA-Z]+)\(");

            MatchCollection methodDeclarationMatches = methodDeclarationPattern.Matches(text.ToString());
            MatchCollection methodCallMatches = methodCallPattern.Matches(text.ToString());

            string parsedText = text.ToString();

            for (int i = 0; i < methodDeclarationMatches.Count; i++)
            {
                string currentMethod = methodDeclarationMatches[i].Groups[1].Value;
                string currentPartision = parsedText.Substring(parsedText.IndexOf(methodDeclarationMatches[i].Groups[0].Value)+methodDeclarationMatches[i].Groups[0].Value.Length, parsedText.IndexOf(methodDeclarationMatches[i+1].Groups[0].Value));
            }





        }
    }
}