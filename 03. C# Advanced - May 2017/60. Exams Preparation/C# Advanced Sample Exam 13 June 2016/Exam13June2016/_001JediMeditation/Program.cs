using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001JediMeditation
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> mastersQueue = new Queue<string>();
            Queue<string> knightsQueue = new Queue<string>();
            Queue<string> padawansQueue = new Queue<string>();
            Queue<string> specialCharactersQueue = new Queue<string>();

            bool isYodaExistent = false;

            for (int i = 0; i < n; i++)
            {
                string[] jedi = Console.ReadLine().Split();

                for (int j = 0; j < jedi.Length; j++)
                {
                    char currentJedi = jedi[j][0];

                    switch (currentJedi)
                    {
                        case 'm':
                            mastersQueue.Enqueue(jedi[j] + " ");
                            break;
                        case 'k':
                            knightsQueue.Enqueue(jedi[j] + " ");
                            break;
                        case 'p':
                            padawansQueue.Enqueue(jedi[j] + " ");
                            break;
                        case 't':
                        case 's':
                            specialCharactersQueue.Enqueue(jedi[j] + " ");
                            break;
                        case 'y':
                            isYodaExistent = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (isYodaExistent)
            {
                StringBuilder output = new StringBuilder();
                output.Append(string.Join("", mastersQueue));
                output.Append(string.Join("", knightsQueue));
                output.Append(string.Join("", specialCharactersQueue));
                output.Append(string.Join("", padawansQueue));
                Console.WriteLine(output.ToString().Trim());
            }
            else
            {
                StringBuilder output = new StringBuilder();
                output.Append(string.Join("", specialCharactersQueue));
                output.Append(string.Join("", mastersQueue));
                output.Append(string.Join("", knightsQueue));
                output.Append(string.Join("", padawansQueue));
                Console.WriteLine(output.ToString().Trim());
            }
        }
    }
}